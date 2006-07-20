/*
 *  This program is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU General Public License
 *  as published by the Free Software Foundation; either version
 *  2 of the License, or (at your option) any later version.
 *
 *  Copyright 2004 Spiro Trikaliotis
 *
 */

#include <windows.h>

#include <stdarg.h>
#include <stdio.h>
#include <assert.h>

#include "arch.h"


/*! \brief Format a returned error code to a string

 This function formats a returned error code into a string.

 \param ErrorCode
   The error number to be formatted.

 \return
   Returns a pointer to the string describing the ErrorCode.

 The buffer the return value points to can be safely used until
 another call to this function occurs.
*/

char *arch_strerror(unsigned int ErrorCode)
{
    static char ErrorMessageBuffer[2048];
    int n;

    // Write the error message into the buffer

    n = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS
                      | FORMAT_MESSAGE_MAX_WIDTH_MASK,
                      NULL,
                      ErrorCode,
                      MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), // Default language
                      (LPTSTR) &ErrorMessageBuffer,
                      sizeof(ErrorMessageBuffer)-1,
                      NULL);

    // make sure there is a trailing zero

    ErrorMessageBuffer[n] = 0;

    return ErrorMessageBuffer;
}

/*! \brief Format a returned error code to screen

 This function formats a returned error code into a string,
 and outputs it onto the screen.

 \param AUnused
   Unused, only for compatibility with Unix

 \param ErrorCode
   The error number to be formatted.

 \param Format
   Format specifier for additional error information.
   Can be NULL.
*/

void arch_error(int AUnused, unsigned int ErrorCode, const char *Format, ...)
{
    va_list ap;
    char ErrorMessageBuffer[2048];
    char ErrorMessageBuffer2[2048];
    char *errorText = NULL;

    UNREFERENCED_PARAMETER(AUnused);

    // Write the optional string into the output

    if (Format && *Format)
    {
        va_start(ap, Format);

        _vsnprintf(ErrorMessageBuffer2, sizeof(ErrorMessageBuffer2), Format, ap);

        va_end(ap);

        // make sure there is a trailing zero

        ErrorMessageBuffer2[sizeof(ErrorMessageBuffer2) - 1] = 0;
    }

    // Get the error message

    if (ErrorCode != 0)
    {
        errorText = arch_strerror(ErrorCode);
    }

    // Append the message to the buffer. Make sure not to overwrite the buffer

    if (errorText)
    {
        _snprintf(ErrorMessageBuffer, sizeof(ErrorMessageBuffer), "%s: %s", ErrorMessageBuffer2, errorText);

        ErrorMessageBuffer[sizeof(ErrorMessageBuffer)-1] = 0;
    }
    else
    {
        assert(sizeof(ErrorMessageBuffer) >= sizeof(ErrorMessageBuffer2));

        strcpy(ErrorMessageBuffer, ErrorMessageBuffer2);
    }

    fprintf(stderr, "%s\n", ErrorMessageBuffer);

#if DBG

    {
        int n = strlen(ErrorMessageBuffer);

        if (n == sizeof(ErrorMessageBuffer))
            --n;

        ErrorMessageBuffer[n] = '\n';
        ErrorMessageBuffer[n+1] = 0;
        OutputDebugString(ErrorMessageBuffer);
    }

#endif
}
