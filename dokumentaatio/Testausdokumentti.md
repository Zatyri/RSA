# Testausdokumentti

## Yksikkötestaus
### Kattavuusraportti
[![codecov](https://codecov.io/gh/Zatyri/RSA/branch/main/graph/badge.svg?token=N5A8G9TN4A)](https://codecov.io/gh/Zatyri/RSA)

### Satunnaisten isojen lukujen testaus
Testaus on laadittu tarkistamaan että palautetut luvut ovat tarpeeksi suuria. Niinden lukujen osalta joiden kuuluu olla parittomia on tätä myös testattu. Testit on toteutettu silmukan avulla, joka testaa satunnaisten lukujen luomista erilaisilla bitti kooilla. 

### Miller-Rabin
Miller-Rabin algoritmin osalta testataan että algoritmi palauttaa epätosi kun luku on yhistelmäluku ja tosi kun luku on alkuluku. Testeissä algoritmille annetaan useampi syöte varmistettuja yhistelmälukuja ja alkulukuja.

### Tiedostoon kirjoittaminen ja lukeminen
Testataan että ohjelma kykenee kirjoittamaan kun ohjelma saa validin polun ja hylkää silloin kun polkua ei ole olemassa.

### Viestien salaaminen ja purkaminen
Testit on laadittu tarkistamaan palauttavatko salaus ja purkaus metodit oikean muotoista palautusarvoa. Testit salaavat ja purkavat viestin ja testi varmistaa että viesti on alkuperäisessä muodossa purkauksen jälkeen.

## Testien toistettavuus
Testejä on helppo toistaa ajamalla yksikkötestit.

## Käyttäjäsyötteet
Ohjelman käyttäjäsyöte osiot ovat testattu manuaalisesti ajamalla ohjelma paikallisesti ja antamalla ohjelmalle syötteitä.




