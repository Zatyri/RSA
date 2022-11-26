# Toteutusdokumentti

## Ohjelman rakenne
Ohjelma on rakennettu käyttämällä palveluluokkia. Jokaisella palveluluokalla on oma vastuualue. Suurin osa palveluluokista ovat toteutettu staattisina, sillä niiden ei tarvitse tallentaa tilaa ja kukin metodi toimii itsenäisesti. 

Ohjelman käynnistettyä pyytää pääluokka (Program.cs) komentoja käyttäjältä. Käyttäjän antaman komennon perusteella kutsuu pääluokka erinäisiä palveluluokkia toteuttaakseen komennon.

## Palveluluokat
### IOService (staattinen)
IOService luokka pyytää käyttäjältä syötteitä, kuten tiedosto polkuja ja numero sekä teksti syötteitä.

### KeyGeneration 
KeyGeneration luokka vastaa julkisen ja salaisen avaimen luonnista. 

### PrimeService
PrimeService luokka luo halutun kokoisia alkulukuja. Luokka käyttää apunaan Miller-Rabin algoritmia luodessaan alkulukuja

### CryptographyService (staattinen)
CryptographyService salaa ja purkaa viestejä salaisen ja julkisen avaimen avulla.

### FileService (staattinen)
FileService kirjoittaa ja lukee avaimia ja viestejä tiedostoihin

## Saavutetut aika- ja tilavaativuudet
(todo-listalla)

## Suorituskyky- ja O-analyysivertailu
(todo-listalla)

## Puutteet ja parannusehdotukset
(todo-listalla

## Lähteet
https://en.wikipedia.org/wiki/RSA_(cryptosystem)

https://www.geeksforgeeks.org/rsa-algorithm-cryptography/

https://www.educative.io/answers/what-is-the-rsa-algorithm

https://www.comparitech.com/blog/information-security/rsa-encryption/

https://rosettacode.org/wiki/RSA_code

https://medium.com/asecuritysite-when-bob-met-alice/so-how-does-padding-work-in-rsa-6b34a123ca1f
