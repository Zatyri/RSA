# Viikkoraportti 4

# Mitä tein viikon aikana
Aloitin viikon tutkimalla miten kannattaisi jakaa salattavia viestejä osiin, jos ne ovat suurempia kuin avaimen bittikoko. Löysin nopeasti viitteitä siihen, ettei näin kannattaisi tehdä, sillä viestin pilkkominen on tietoturva riski. Oikea tapa salata pidempiä viestejä on käyttää symmetristä salausta kuten AES salaus tekniikkaa ja salata AES salaukseen käytettyä avainta RSA salauksella. Olihan tästä puhetta "Cyber security" kurssilla.

Löysin lähteistä että RSA salauksen parantamiseen kannattaisi salattavaan viestiin listätä "padding". Tutkin erilaisia padding vaihtoehtoja ja löysin kaksi yleistä tapaa. Ei niin turvallinen PKCS#v1.5 ja turvallisempi OAEP. Totesin kuitenkin, että OAEP on tämän tehtävän raamien ulkopuolella ja aikomuksena on lisätä PKCS#1.5 padding ohjelmaan.

Ohjelmoinnin saralla toteutin alkeellisen käyttöliittymän joka mahdollistaa nykyhetkessä avainparin luonnin ja niiden tallentaminen tiedostoon, viestin salauksen ja sen tallentaminen tiedostoon sekä viestin purkamisen. Tein myös parannuksia isojen satunnaisten numeroiden luontiin ja kirjoitin testejä. Jouduin myös debuggaa gitHub Actionsin workfilea koska aikaisemmin toimineet komennot hajosivat ja kaipasivat pientä muutosta.

Tällä hetkellä testataan kaikkia muita luokkia unit-testeillä laajasti mutta käyttäjäsyötteitä ottavat luokat on ainoastaan manuaalisen testauksen varassa.

Käytin viikon aikana noin 10 tuntia

# Mitä opin
Opin että RSA viestejä ei kannata pilkkoa, vaan käyttää vaihtoehtoisia salausmenetelmiä tai niiden yhdistettä kuten RSA + AES. Opin myös että RSA viesteihin kannattaa lisätä "padding" jotta saman muotoiset tai identtiset viestit eivät olisi salattuna saman muotoisia. Opin myös että on eri menetelmiä tehdä padding, ja luoda viesteihin satunnaisuutta. 

# Tämä on epäselvää
En ole C#:illa aikaisemmin kirjoittanut testejä konsolin käyttäjäsyötteille. Lyhyen tutkimisen peruseteella en tullut sen viisaammaksi. Onko tämän kurssin vaatimuksena että käyttäjäsyötteitä hallinoiva palveluluokka testataan?
Varmistaisin myös, että arvioini toteuttaa ei tietoturvallinen PKCS#1.5 padding-menetelmä, turvallisemman OAEP menetelmän sijaan, on oikea tämän kurssin puitteessa.

# Mitä seuraavaksi
Seuraavalla viikolla parantelen käyttöliittymään (esim virheviestejä yms. hienosäätöä). Lisään PKCS#1.5 padding-menetelmän viesteihin. Jos aikaa jää toteutan myös alkulukujen luontiin kevyemmän alkutarkistuksen, ennen Miller-Rabin algoritmia ja vertailen suorituskykyä.
