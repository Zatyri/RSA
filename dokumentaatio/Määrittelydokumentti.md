# RSA projekti
Opinto-ohjelma: Tietojenkäsittelytieteen kandidaatti (TKT)

Projektin kielet:
- Dokumentaatio: Suomi
- Koodi (Muuttujat, funktiot yms.): Englanti

## Ohjelmintikielet
Tämä projekti toteutetaan C# ohjelmointikielellä. Valitsen C# koska se on kieli jota käytän työssäni eniten ja on minulle JavaScriptin rinnalla kieli, jota osaan parhaiten. En ole tutustunut C#:in dokumentaation luonti ominaisuuksiin. Käytän ohjelmoitaessa metodien XML dokumentointia IDE:n IntelliSensiä varten, mutta en ole luonut siitä erillistä dokumenttia. Tämä lienee mahdollista Sandcastle työkalun avulla. 

### Kielet joita hallitsen
- C# ja JavaScript (myös jonkin verran TypeScript:iä) ovat kielet joita osaan parhaiten. Käytän nämä kielet päivittäisessä työssäni sekä omissa projekteissa. 
- Javaa olen opiskellut (lähinnä yliopiston kursseilla), mutta en ole muuten käyttänyt.
- C++:aan olen tutustunut Algoritmit Ongelmanratkaisu kurssilla, mutta taidot ovat toistaiseksi varsin alkeelliset.
- Pytonia hallitsen koska jotkut yliopiston kurssit vaativat sen käytön, mutta taidot ovat toistaiseksi varsin alkeelliset.

## RSA ohjelma
Tämän projektin lopputuloksena on ohjelma jolla voi luoda julkisia ja salaisia avainpareja RSA salausta varten. Ohjelmalla voi myös salata ja purkaa viestejä. 
Avainten luontiin voi ohjelmaan syöttää avainten haluttu vahvuus (bitteinä). Avaimet tallennetaan tekstitiedostoon.
Ohjelma sisältää kentän johon voi syöttää salaamaton tai salattu viesti. Ohjelma salaa/purkaa viestin.
Ohjelmaa käytetään konsolin kautta.

## Projektin algoritmit
### Suurten alkulukujen löytäminen
Suurien alkulukujen löytämiseen käytän parittomia satunnaisia numeroita ja testaan ovatko ne alkulukuja Miller-Rabin testillä. 
Jos satunnisesti valittu numero ei ole alkuluku lisätään lukuun 2 ja testataan se uudestaan. Näin tarvitaan keskimäärin 1/177 arvausta (512 bittisen alkuluvun) löytääkseen alkuluvun.

Toteutan myös alemman luokan alkulukutestin, jossa ohjelma yrittää jakaa satunnaista numeroa ensimmäisten sadan alkuluvun kanssa, ja mittaan sen vaikutusta alkuluvun löytämiseen. Ensimmäisten satojen alkulukujen löytämiseen käytän Sieve of Eatosthenes algoritmia. 

### RSA algoritmin salaus ja purkaus
Julkisen avaimen toisen osan löytämiseen käytän Euclideanin algoritmia.

Julkisen ja salaisen avaimen luominen on tämän jälkeen melko suoraviivaista.

### Algoritmien aika- ja tilavaativuudet
Miller-Rabin aikavaativuus on O(k log^3 n) jossa k on testikierrosten määrä ja n testattava luku ja tilavaativuus O(1).

Sieve of Eatosthenes aikavaativuus on O(n log(log(n)) ja tilavativuus O(1)

## Lähteet
https://www.geeksforgeeks.org/rsa-algorithm-cryptography/

https://www.geeksforgeeks.org/sieve-of-eratosthenes/

https://www.comparitech.com/blog/information-security/rsa-encryption/


