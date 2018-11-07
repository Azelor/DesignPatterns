# Delivery Application

### Rakenduse kirjeldus ja eeldused edasiarendamiseks
1. Vedude teostamiseks on neli erinevat sõiduki liiki - DeliveryBike, DeliveryCar, DeliveryVan, DeliveryTruck.
2.  Iga sõiduk on omaette klass koos Deliver() meetodiga, mis kirjutab konsooli, kui sõiduk tarnib kaupa. Näiteks DeliveryBike klassi Deliver() meetod kirjutab “Bike makes a delivery”. Tegelikkuses on sõidukitel ka neile omased muutujad, kuid lihtsuse mõttes piirdume vaid ühe meetodiga.

### Nõuded 

Rakenduse täiendamiseks on püstitatud neli nõuet. 

1.   Lisaks sõidukitele on olemas ka pakiautomaat, millel on ProvidePickup() meetod. `ParcelLocker - realiseeritud kasutatud Adapter disainimustrit`
    
2.   Vedusid ja pakiautomaadist korjatud pakkide koguarvu peab saama loendada. (Printida välja kõik kokku ühe arvuna). `DeliveryCounter - realiseeritud kasutatud Facade disainimustrit`
    
3.   Sõidukite ja pakiautomaatide objekte saab luua eraldi klassist. `Factory - realiseeritud kasutades Abstract Factory disainimustrit`
    
4.   Sõidukeid ja pakiautomaate saab grupeerida ning seejärel teostada vedu juba loodud grupiga. (Ühe käsuga teostatakse mitu vedu) `Fleet - realiseeritud kasutades Composite disainimustrit`

### Testid
- Ühiktestide kirjutamiseks on kasutatud MSTest raamistikku.
- Iga nõude (disainimustri) kohta on eraldi teistest sõltumatud testid ja eksisteerivad ka testid (Combined tests), mis kontrollivad kõikide nõuete koostoimimist.
- Testitakse konsooli kirjutatu vastavust oodatud tulemusele. Konsooli teksti püüdmiseks on loodud kaks abimeetodit - BeginReading, mis alustab lugemist ja EndReading, mis väljastab konsooli kirjutatud read Listina. 

### Juhend
[Juhend mustrite realiseerimiseks (ilma testideta)](https://docs.google.com/document/d/1oKW_mMJOuoU4IqpMaTzyE6c7dbUvDWRfCypAAJQdjjw/edit?usp=sharing)