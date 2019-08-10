# WeatherStation_API
This can be a possible API for us to use with our project subject next semester.

* I have added the basic layout for the project's backend. 
* I will teach everything I've learned to you and I think this will get us the fastest up and running.

Web API Details
----------------
- .Net Core 2.2 
- Entity Framework Core
- Database:
```bash
coen@WeatherStationAPI:~$ mysql --version
mysql  Ver 14.14 Distrib 5.7.27, for Linux (x86_64) using  EditLine wrapper
```

WeatherUnderground Details
--------------------------
* Email : 28410629@student.g.nwu.ac.za
* Password : Olideadsykes1
* API Key : 7a085e4a3b754ef4885e4a3b755ef490
* API Documentation : [Online Documentation](https://docs.google.com/document/d/1eKCnKXI9xnoMGRRzOL1xPCBihNV2rOet08qpE_gArAY/edit)

Reference Links
---------------
* [Publishing an ASP.NET Core website to a cheap Linux VM host](https://www.hanselman.com/blog/PublishingAnASPNETCoreWebsiteToACheapLinuxVMHost.aspx)
* [Datatypes for EF] (https://www.devart.com/dotconnect/mysql/docs/DataTypeMapping.html)

Certificate For API
-------------------

Generate certificate for API:

See [https://tecadmin.net/install-lets-encrypt-create-ssl-ubuntu/](https://tecadmin.net/install-lets-encrypt-create-ssl-ubuntu/)

```bash
coen@WeatherStationAPI:~$ sudo certbot-auto certonly --standalone -d weatherstationapi.ddns.net 
Saving debug log to /var/log/letsencrypt/letsencrypt.log
Plugins selected: Authenticator standalone, Installer None
Obtaining a new certificate

IMPORTANT NOTES:
 - Congratulations! Your certificate and chain have been saved at:
   /etc/letsencrypt/live/weatherstationapi.ddns.net/fullchain.pem
   Your key file has been saved at:
   /etc/letsencrypt/live/weatherstationapi.ddns.net/privkey.pem
   Your cert will expire on 2019-10-25. To obtain a new or tweaked
   version of this certificate in the future, simply run certbot-auto
   again. To non-interactively renew *all* of your certificates, run
   "certbot-auto renew"
 - If you like Certbot, please consider supporting our work by:

   Donating to ISRG / Let's Encrypt:   https://letsencrypt.org/donate
   Donating to EFF:                    https://eff.org/donate-le
```

Create usable certificate for API:

```bash
openssl pkcs12 -export -out certificate.pfx -inkey privkey.pem -in cert.pem -certfile chain.pem
```

An important concept to think of in regards to Web APIs
-------------------------------------------------------
So in other words, don't do computation on the front-end side since the code is publically available with web technologies.
The back-end will always serve the data being displayed on the front-end side.

![Capture0730](https://user-images.githubusercontent.com/20205514/62110724-5a913f00-b2af-11e9-913d-67cae731e1e5.PNG)

