#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main ( int argc, char *argv[] )
{
    printf("Enter the file name: \n");
    //scanf
    if ( argc != 2 ) /* argc should be 2 for correct execution */
    {
        /* We print argv[0] assuming it is the program name */
        printf( "usage: %s filename", argv[0] );
    }
    else
    {
        // We assume argv[1] is a filename to open
        FILE *file = fopen( argv[1], "r" );
	int size = strlen(argv[1] + 5);
	char buff[size];
	strcpy(buff, argv[1]);
	strcat(buff, ".bin");
	FILE *output = fopen(buff, "w");
        /* fopen returns 0, the NULL pointer, on failure */
        if ( file == 0 )
        {
            printf( "Could not open file\n" );
        }
        else
        {
            int x;
            /* Read one character at a time from file, stopping at EOF, which
               indicates the end of the file. Note that the idiom of "assign
               to a variable, check the value" used below works because
               the assignment statement evaluates to the value assigned. */
            while  ( ( x = fgetc( file ) ) != EOF )
            {
                printf( "%c", x );
            }
            fclose( file );
	    fclose(output);
        }
    }
    return 0;
}

