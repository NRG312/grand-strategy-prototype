using UnityEngine;

public class PlanDzialania : MonoBehaviour
{
    //Wykonanie Prototypu
    //poruszanie kamera po mapie
    //Mapa(Interaktywne prowincje,UI(nazwy prowincji),mozliwosc chodzenia prototypem wojska,podswietlone prowincje kolorami wzgledem kraju)
    //ekonomia
    //wojsko,Walka
    //system dyplomacji
    //zarzadznie podstawowe krajem
    //przejmowanie prowicji


    //Na czym skonczylem i dalsza praca

    //skonczylem na robieniu mapy(zrobilem optymalizacje poczatkowa, przydalyby sie kamienie i sciezki jakies proste dorobic, pnie powalone jako ozdobe rowniez)

    //Przed tym co na gorze co robilem
    //Skonczylem na robieniu fabryki dla unitarmy,dodalem event dla zaznaczania armii,ulepszylem funkcje z garnizonem,ArmyProvinceUI,UnitArmy i ArmyManager
    
    //pomysly
    //przemysl czy chodzenie armii powinno byc takie ze ida sami w tym kierunku czy np jak w europce ze zaznaczam na prowincje i na srodek prowincji sie kieruja w zaleznosci od predkosci
    //, Dokonczenie UI dla jednostek, usuwanie armii i odeslanie do garnizonu jednostek, ustawienie aby jednostki nie wchodzily w siebie(Add army merging and management tak nazwij commita),trzeba dorobic namespacey


    //Bledy
    //jest blad jak klikne prowincje wypuszcze armie i chce kliknac na armie ta co zrobilem to wywala blad w highlightprovince znajdz przyczyne i zacznij robic ArmyUI aby szczegoly armii pokazalo




    //szybki opis jak dzialaja funkcje

    //PROWINCJE
    //Selecting Province(podswietlanie)
    //eventmanager -> ProvinceSelectEvent -> ProvinceSelector(Wywołanie eventu) -> ProvinceManager,HighlightProvince,ProvinceUI

    //Searching for owner Province
    //ProvinceManager -> foreach Province[] -> NationManager(szukanie po ID) -> zwraca Nation -> ProvinceManager wysyla dla zmiennej owner w provincji zwroconą dane

    //Changing owner province
    //future function -> provinceUI(setnewowner) -> NationManager(returning nation by ID)

    //Przeplyw danych do NationUI
    //Guzik w provinceUI -> wywoluje TurnOnNationPage -> NationUI InitUI -> Przypisanie danych do TMP_text -> pobieranie danych z Nation

    //Przypisywanie Prowincji dla Nacji
    //ProvinceManager(Inicjacja) -> Province(InitOwner) -> przypisanie nowej prowincji dla Nacji

    //Prototyp Przypisywania prowincji dla nowego ownera
    //Guzik w panelu province transfer -> ProvinceUI(setnewowenr) po ID -> Province(setnewowner) -> NationManager po ID wyszukuje dana nacje -> zwraca Nacje i province przypisuje nowego ownera

    //ARMIA
    //Armia przeplyw danych do wyswietlenia UI w ArmyProvince
    //Garnizon(klasa w Province)(trzyma referencje UnitType) -> ArmyProvinceUI zapisuje liste garnzonu -> sprawdza i inicjuje prefab w UI -> wyswietla dane
    //Armia przeplyw danych do wysweitlenia UI w ArmyUI
    // -------------------> tutaj dopisz jak zrobisz
    //Tworzenie Armii
    //ArmyProvinceUI wywoluje event przekierowujac province->ArmyManager(Create Army) -> z objectPoola pobiera wolna jednostke -> tworzy jednostke z UnitArmy i przypisuje jej wszystkie dane -> ustawia pozycje i pobiera liste garnizonu do swoich jednostek -> usuwa garnizon
    //Zaznaczanie armii(z box selectorem)
    //MapSelector -> wykrywa czy zaznaczam wiele obiektor -> przekazuje startposition i dane o zaznaczaniu wielu obiektow -> boxselector tworzy boxa i sprawdza po layerze co jest w srodku boxa -> zwraca liste obiektow zaznaczonych
    //Zaznaczanie armii(wizualne na mapie)
    //MapSelector zapisuje liste i wywoluje event UnitsArmySelectEvent -> w srodku mapselector sprawdza po liscie jakie sa zaznaczone armie -> wywoluje funkcje onselect dla poszczegolnego unitu
    //System garnizonu w panelu prowincji
    //ArmyProvinceUI trzyma wszystkie prefaby -> podczas selectowania prowincji odswieza garnizon i sprawdza jakie sa jednostki -> wlacza odpowiednia ilosc prefabow i inicjuje je -> usuwa kiedy wywolany jest event z tworzeniem armii w ArmyProvinceUI

    //SUROWCE
    //Przypisanie dla prowincji surowcow
    //ProvinceSO -> ResourceDeposit ktory trzyma jaki surowiec wystepuje na tej prowincji(obfitosc, bonus za wykopanie) ->




    //GAME ARCHITECTURE
    //Nation,NationManager,NationSO
    //Province,ProvinceSO,ProvinceUI,HighlightProvince,ProvinceManager
    //CameraMovement, ProvinceSelector

    //NATION
    //- dane państwa
    //-runtime state

    //NationUI
    //wysweitlanie szczegołów danej nacji
    //NATION MANAGER
    //-tworzenie Nation
    //- wyszukiwanie Nation

    //PROVINCE MANAGER
    //- tworzenie prowincji
    //- zarządzanie prowincjami

    //PROVINCE
    //- dane prowincji
    //- owner
    //- identyfikacja

    //PROVINCE SELECTOR
    //-kliknięcie
    //- wybór prowincji

    //PROVINCE UI
    //- wyświetlanie informacji

    //UnitArmy
    //unit armii tworzony na mapie
    //ArmyManager

    //BattleManager

    //UnitType
    //typ jednostek jak kawaleria itp.

    //UnityTypeSO


    //Garrison
    //w klasie Province trzyma dana ilosc garnizonu

    //ArmyProvinceUI
    //zarzadza armia w prowicji

    //ArmyUI
    //zarzadza kliknieta armia
}
