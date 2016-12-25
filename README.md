# Boop

Boop is a C# implementation of the [servefiles.py from FBI](https://github.com/Steveice10/FBI/tree/2.4.5/servefiles)

Boop is completely rewritten in C# and thus is snek free (No python needed).

I made the gui as simple as I could:
* Write the IP adress from the 3ds
* Pick your cia or tik files
* Boop'em to your 3ds.

(Note for nerds: The only way I found to bypass windows firewall with the current implementation of httplistener was poking a hole in it and then patching the hole. It is shady, but I couldn't find a better way)
