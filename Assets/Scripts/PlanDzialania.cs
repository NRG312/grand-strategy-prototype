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

    //Skonczylem na robieniu Armii w UnitArmy robie wstepna wizualna strone i trzeba zrobic UnitArmy i stworzenie jej w samej grze

    //






    //szybki opis jak dzialaja funkcje

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


    //Armia przeplyw danych do wyswietlenia UI
    //Garnizon(klasa w Province)(trzyma referencje UnitType) -> ArmyUI sprawdza garnizon poprzez selected_province -> zapisuje w swojej liscie(UnitType) -> wyswietla dane na TMP_text
    //Tworzenie Armii
    //ArmyManager(Create Army) -> z objectPoola pobiera wolna jednostke -> tworzy jednostke z UnitArmy i przypisuje jej wszystkie dane//(to popraw gdy zrobisz ta funkcje)





    //Nation zwykla klasa C# bo nie potrzebny jest jako obiekt, moge w nim stworzyc caly kraj i działac na aktualnych pieniadzach aktualnej armi i aktualnym wlascicielu

    //Nation,NationManager,NationSO
    //Province,ProvinceSO,ProvinceUI,HighlightProvince,ProvinceManager
    //CameraMovement, ProvinceSelector



    //GAME ARCHITECTURE

    //NATION
    //- dane państwa
    //-runtime state

    //NationUI

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

    //ArmyManager

    //BattleManager

    //UnitType

    //UnityTypeSO

    //ArmyVisual

    //Garrison
    //w klasie Province trzyma dana ilosc garnizonu

    //ArmyUI
}
