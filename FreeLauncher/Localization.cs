namespace FreeLauncher
{
    public class Localization
    {
        public string Name = "Русский";
        public string LanguageTag = "ru-RU";
        public string Authors = "dedepete";

        #region LauncherForm

        #region Tabs

        public string NewsTabText = "НОВОСТИ";
        public string ConsoleTabText = "КОНСОЛЬ";
        public string ManageVersionsTabText = "УПРАВЛЕНИЕ ВЕРСИЯМИ";
        public string AboutTabText = "О ЛАУНЧЕРЕ";
        public string LicensesTabText = "ЛИЦЕНЗИИ";
        public string SettingsTabText = "НАСТРОЙКИ";

        #endregion

        #region Main Controls

        public string LaunchButtonText = "Запуск игры";
        public string AddProfileButtonText = "Добавить профиль";
        public string EditProfileButtonText = "Изменить профиль";

        #endregion

        #region About Tab

        public string DevInfo = "Разработано dedepete";
        public string GratitudesText = "Благодарности";
        public string GratitudesDescription = "Большое спасибо администрации портала ru-minecraft.ru за содействие в развитии проекта!";
        public string PartnersText = "Партнёры";
        public string MCofflineDescription = "MCoffline - лучшая программа для серверных администраторов!";
        public string CopyrightInfo = "\"Minecraft\" является торговой маркой Mojang AB. Все права защищены.\nMojang AB является дочерней студией Microsoft Studios.";

        #endregion

        #region Settings Tab

        public string EnableMinecraftUpdateAlertsText = "Показывать уведомления о наличии новых версий Minecraft";
        public string EnableMinecraftLoggingText = "Выводить лог игры в консоль";
        public string UseGamePrefixText = "Использовать префикс [GAME] для логов Minecraft";
        public string CloseGameOutputText = "Закрывать вкладку, если завершение было вызвано\nпринудительно или прошло без ошибок";

        #endregion

        public string Launch = "Запустить";
        public string OpenLocation = "Открыть расположение";
        public string DeleteVersion = "Удалить версию";
        public string DeleteConfirmationTitle = "Подтверждение удаления";
        public string DeleteConfirmationText = "Вы действительно хотите удалить версию {0}?";
        public string ReadyToLaunch = "Готов к запуску версии {0}";
        public string ReadyToDownload = "Готов к загрузке версии {0}";
        public string EditingProfileTitle = "Редактирование профиля";
        public string ProfileAlreadyExistsErrorText = "Данный профиль уже существует в списке!";
        public string ProfileDeleteConfirmationText = "Вы действительно хотите удалить профиль '{0}'?";
        public string AddingProfileTitle = "Добавление профиля";
        public string CheckingVersionAvailability = "Выполняется проверка доступности версии '{0}'";
        public string CheckingLibraries = "Выполняется проверка библиотек";
        public string GameOutput = "ВЫВОД ИГРЫ";
        public string KillProcess = "Убить процесс";
        public string Independent = "Независимая";

        #endregion

        #region ProfileForm

        #region Main Settings

        public string ProfileName = "Название профиля:";
        public string WorkingDirectory = "Рабочая директория:";
        public string WindowResolution = "Разрешение окна:";
        public string ActionAfterLaunch = "Действие после запуска:";
        public string Autoconnect = "Автоподключение:";

        #endregion

        #region Version Selection

        public string Snapshots = "Отображать экспериментальные сборки (\"snapshots\")";
        public string Beta = "Отображать старые \"Beta\" сборки(2010-2011)";
        public string Alpha = "Отображать старые \"Alpha\" сборки(от 2010)";
        public string Other = "Отображать сторонние версии(Forge, LiteLoader, etc.)";
        public string UseLatestVersion = "Использовать последнюю версию";

        #endregion

        #region Java Options

        public string JavaExecutable = "Исполняемый файл:";
        public string JavaFlags = "Флаги JVM:";

        #endregion

        public string OpenDirectory = "Открыть раб. директорию";

        public string JavaDetectionFailed =
            "Не удалось определить путь до Java! Пожалуйста, укажите путь к исполняемому файлу вручную.";

        #endregion

        #region UsersForm

        public string AddNewUserBox = "Добавление нового пользователя";
        public string Nickname = "Ник/Логин:";
        public string LicenseQuestion = "У вас лицензионный аккаунт?";
        public string Password = "Пароль:";
        public string AddNewUserButton = "Добавить нового пользователя";
        public string RemoveSelectedUser = "Удалить выбранного пользователя";
        public string IncorrectLoginOrPassword = "Логин и/или пароль введены неверно!";
        public string PleaseWait = "Пожалуйста, подождите";

        #endregion

        public string Error = "Ошибка";
        public string Cancel = "Отмена";
        public string Close = "Закрыть";
        public string Save = "Сохранить";
    }
}
