# Testausdokumentti

## Yksikkötestaus
### Kattavuusraportti
[![codecov](https://codecov.io/gh/Zatyri/RSA/branch/main/graph/badge.svg?token=N5A8G9TN4A)](https://codecov.io/gh/Zatyri/RSA)

### Satunnaisten isojen lukujen testaus
Testaus on laadittu tarkistamaan että palautetut luvut ovat tarpeeksi suuria. Niinden lukujen osalta joiden kuuluu olla parittomia on tätä myös testattu

### Miller-Rabin
Miller-Rabin algoritmin osalta testataan että algoritmi palauttaa epätosi kun luku on komposittii ja tosi kun luku on alkuluku. Testeissä algoritmille annetaan useampi syöte komposiitti ja varmistettuja alkulukuja.

### Tiedostoon kirjoittaminen ja lukeminen
Testataan että ohjelma kykenee kirjoittamaan kun ohjelma saa validin polun ja hylkää silloin kun polkua ei ole olemassa.

## Testien toistettavuus
Testejä on helppo toistaa ajamalla yksikkötestit.




