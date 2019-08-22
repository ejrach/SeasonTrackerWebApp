This is a demostration of UDP (User Datagram Protocol) and is an alternative to TCP.

UDP tolerates packet loss, and is used in applications like gaming, voice and video where
its ok that packets are missed.

It can also be used where a large number of clients are connected and real-time error correction
isn't necessary.

//UDP (User Datagram Protocol) header format:
// 0            15 16           31
// -------------------------------
// | source port  |  dest port   |
// -------------------------------
// | UDP length   |  checksum    |
// -------------------------------

source port - is the number of the sender
dest port - is the port the datagram is addressed to
length - is the length of bytes of the UDP header and any encapsulated data
Checksum - is required in IPv6 and optional in IPv4

