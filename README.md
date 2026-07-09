# EDVirtualCOM2TCP
Generate a Virtual COM and connect it to an IP address. For Windows, .Net 4.8.

Can need 
- com0com
https://sourceforge.net/projects/com0com/files/
Version 3.0 is not compatible to Windows 11. Use version 2.2.
- Hub4Com
https://sourceforge.net/projects/com0com/files/hub4com /.../hub4com-...-386.zip

# Sources :
https://github.com/edvariables/EDVirtualCOM2TCP

# Download
https://edv.edvariables.net/download/EDVirtualCOM2TCP/

Setup seems incompatible with Windows 11 : download directory .zip file.
https://edv.edvariables.net/download/EDVirtualCOM2TCP/EDVirtualCOM2TCP.zip

---------
ED 2026
admin@edvariables.net

---------

3 modes de fonctionnements :

- Com0Com & Hub4Com
	Génèrent des ports virtuels et établit une passerelle avec une adresse IP.
	
- Com0Com & Passerelle interne
	Génèrent des ports virtuels et établit une passerelle avec une adresse IP.
	Ne nécessite pas de Hub4Com.
	
- COMs virtuels existants & Passerelle interne
	Utilisent une paire de ports virtuels, installée avec SerialTool par exemple, et établit une passerelle avec une adresse IP.
	Ne nécessite ni Com0Com ni Hub4Com.
	
	