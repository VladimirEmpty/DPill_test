# DPill_test

## Описание 

Тестовое задание на вакансию [Untiy разработчика](hh.ru/vacancy/69730748?from=favorite_vacancy_list&hhtmFrom=favorite_vacancy_list)
[Исполнитель Гуренев В.Ю.](hh.ru/resume/fc448aaaff0b4860b30039ed1f3362646e7833)
[APK-билд](https://drive.google.com/file/d/1flPwweuPnv7Biwsep_gB4Xo1pRFnhuO2/view?usp=sharing)

## Точки интереса в проекте

* Весь проект стартует из класса [GameInstaller](https://github.com/VladimirEmpty/DPill_test/blob/main/Assets/DPiLL_CODE/Installer/GameInstaller.cs) основная задача, настройка зависимостей и основных core сущностей;проекта.
* В проекте есть [папка](https://github.com/VladimirEmpty/DPill_test/tree/main/Assets/DPiLL_CODE/Setting) с основными настройками игровых сущностей проекта, таких как Враги, Игрок и Бонусы;
* Основная работа игровых сущностей происходит за счет работы [StateMachine](https://github.com/VladimirEmpty/DPill_test/tree/main/Assets/DPiLL_CODE/StateMachine), данная работа включает также модификаторы игрока(например [Модификатор Стрельбы](https://github.com/VladimirEmpty/DPill_test/tree/main/Assets/DPiLL_CODE/StateMachine/State/Modifire/Player/Shoot))
* Работа с физическими взаимодействиями происходит через настроечную таблицу коллизий
* GUI в проекте представлен упрощенной версией [MVC](https://github.com/VladimirEmpty/DPill_test/tree/main/Assets/DPiLL_CODE/GUI/MVC), все взаимодействие идет через [ConectorMVC](https://github.com/VladimirEmpty/DPill_test/blob/main/Assets/DPiLL_CODE/GUI/MVC/ConectorMVC.cs) 
* Реализованы прочие мелкий паттерны и фичи, без излишеств

## Спасибо за внимание!