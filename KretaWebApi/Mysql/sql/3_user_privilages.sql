CREATE USER 'kretamysql'@'%' IDENTIFIED BY 'kreta';
GRANT SELECT, INSERT, UPDATE, DELETE ON `kreta`.* TO 'kretamysql'@'%'; 
FLUSH PRIVILEGES;