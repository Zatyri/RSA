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
### Luo kaksi satunnaista numero bitti-koolla n
```
1. Lisää n:ään bittejä niin että n mod 8 = 0
2. Luo kaksi bitti listaa pituudella n - O(n)
3. Iteroi kummankin listan yli samassa silmukassa asettaen satunnaisesti kukin bitti todeksi / epätodeksi - O(n)
4. Aseta eka ja vika bitti todeksi (varmistaa että koko bittijoukko on käytettävissa ja että numero on pariton
5. Muuta bittilistat tavulistoiksi - O(n)
6. Palauta tavulistat numeroina
```
Tilavaativuus on O(n)
Aikavaativuus on O(n)

### Tarkista onko satunnaiset luvut alkulukuja (ei sisällä Miller-Rabin testin analyysia)
```
1. Tarkista onko luku 2 tai 3 ja palauta tosi jos on
2. Tarkista onko luku alle 2 ja palauta epätosi jos on
3. Tarkista onko luku jaollinen 100 ensimmäisen alkuluvun kanssa, palauta epätosi jos on - O(n)
4. Laske luvusta pienin luku p joka on pienemi kuin luku ja on jaollinen kahden kanssa - O(log n)
5. Suorita Miller-Rabin testi k kertaa, lopeta jos Miller-Rabin palauttaa epätosi - k on konstantti
6. Jos Miller-Rabin testi palauttaa epätosi. Lisää lukuun 2 ja suorita testi uudelleen kunnes Miller-Rabin testi palauttaa tosi k kertaa - O(n)
7. Toista kohdata 1-6 toiselle alkuluvulle - Lisää tarkistus että toinen löydetty alkuluku ei ole sama kuin ensimmäinen. Jos on lisää kaksi lukuun ja jatka kohtaa 6. kunnes löytyy toinen alkuluku
```
Tilavaativuus on O(n)
Aikavaativuus on O(n + log n)

### Miller-Rabin testi
```
1. Laske satunnainen numero r joka on yhtä iso kuin testattava luku - sama aika/tilavaativuus kuin kahden satunnaisen luvun luonti - O(n)
2. Nosta r potenssiin p (saatu edellisestä osiosta) ja laske jakojäännös testattavalla luvulla
3. Palauta tosi jos jakojäännös on 1 tai testattava luku - 1
4. Nosta jakojäännös potenssiin 2 ja laske jakojäännös testattavalla luvulla kunnes jakojäännös on 1 ja palauta epätosi tai laskettava luku - 1 on yhtä kuin jakojäännös ja palauta tosi. Kertaa joka kerralla p kahdella ja lopeta jos p on yhtä kuin testattava luku - 1 ja palauta epätosi - O(log n) 
```
Jos testi palauttaa epätosi on testattava luku 100% varmuudella yhdistelmäluku ja jos testi palauttaa tosi on testattava luku todennäköisesti alkuluku 
Tilavaativuus on O(n)
Aikavaativuus on O(n + log n)

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
