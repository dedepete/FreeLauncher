namespace FreeLauncher
{
    public class ApplicationLocalization
    {
        public string Name { get; set; } = "Русский";
        public string LanguageTag { get; set; } = "ru_RU";
        public string Authors { get; set; } = "dedepete";

        #region LauncherForm

        #region Tabs

        public string NewsTabText { get; set; } = "НОВОСТИ";
        public string ConsoleTabText { get; set; } = "КОНСОЛЬ";
        public string ManageVersionsTabText { get; set; } = "УПРАВЛЕНИЕ СБОРКАМИ";
        public string AboutTabText { get; set; } = "О ЛАУНЧЕРЕ";
        public string LicensesTabText { get; set; } = "ЛИЦЕНЗИИ";
        public string SettingsTabText { get; set; } = "НАСТРОЙКИ";

        #endregion

        #region Main Controls

        public string LaunchButtonText { get; set; } = "Запуск игры";
        public string AddProfileButtonText { get; set; } = "Добавить профиль";
        public string EditProfileButtonText { get; set; } = "Изменить профиль";
        public string SetToClipboardButtonText { get; set; } = "Скопировать в буфер";

        #endregion

        #region Build Managment Tab

        public string VersionHeader { get; set; } = "Версия";
        public string TypeHeader { get; set; } = "Тип";
        public string ReleaseDateHeader { get; set; } = "Дата выхода";
        public string LastUpdatedHeader { get; set; } = "Последнее обновление";
        public string AssetsIndexHeader { get; set; } = "Индекс ресурсов";
        public string DependencyHeader { get; set; } = "Зависит от";
        
        public string Restore { get; set; } = "Восстановить";
        public string OpenLocation { get; set; } = "Открыть расположение";
        public string DeleteVersion { get; set; } = "Удалить сборку";
        public string DeleteConfirmationTitle { get; set; } = "Подтверждение удаления";
        public string DeleteConfirmationText { get; set; } = "Вы действительно хотите удалить сборку '{0}'?";

        #endregion

        #region Profile Managment Tab

        public string MoveUp { get; set; } = "Переместить вверх";
        public string MoveDown { get; set; } = "Переместить вниз";
        #endregion

        #region About Tab

        public string DevInfo { get; set; } = "Разработано dedepete";
        public string GratitudesText { get; set; } = "Благодарности";
        public string GratitudesDescription { get; set; } = "Администрации портала ru-minecraft.ru за содействие в развитии проекта!";
        public string PartnersText { get; set; } = "Партнёры";
        public string MCofflineDescription { get; set; } = "MCoffline - лучшая программа для серверных администраторов!";

        public string CopyrightInfo { get; set; } =
            "\"Minecraft\" является торговой маркой Mojang Synergies AB. Все права защищены.\nMojang Synergies AB является дочерней студией Microsoft Studios.";

        #endregion

        #region Settings Tab

        public string MainSettingsTitle { get; set; } = "Основные";
        public string CheckUpdatesCheckBox { get; set; } = "Проверять наличие обновлений лаунчера";
        public string SkipAssetsDownload { get; set; } = "Пропускать загрузку ресурсов";
        public string EnableMinecraftLoggingText { get; set; } = "Выводить лог игры в консоль";
        public string LoggerSettingsTitle { get; set; } = "Логирование";

        public string CloseGameOutputText { get; set; } =
            "Закрывать вкладку, если завершение было вызвано\nпринудительно или прошло без ошибок";

        #endregion

        public string Launch { get; set; } = "Запустить";
        public string Delete { get; set; } = "Удалить";
        public string ReadyToLaunch { get; set; } = "Готов к запуску сборки {0}";
        public string ReadyToDownload { get; set; } = "Готов к загрузке сборки {0}";
        public string EditingProfileTitle { get; set; } = "Редактирование профиля";
        public string ProfileAlreadyExistsErrorText { get; set; } = "Данный профиль уже существует в списке!";
        public string ProfileDeleteConfirmationText { get; set; } = "Вы действительно хотите удалить профиль '{0}'?";
        public string AddingProfileTitle { get; set; } = "Добавление профиля";
        public string CheckingVersionAvailability { get; set; } = "Выполняется проверка доступности сборки '{0}'";
        public string CheckingLibraries { get; set; } = "Выполняется проверка библиотек";
        public string GameOutput { get; set; } = "ВЫВОД ИГРЫ";
        public string KillProcess { get; set; } = "Убить процесс";
        public string Independent { get; set; } = "Самостоятельная";
        public string InvalidSessionMessage { get; set; } = "Токен сеанса устарел. Пожалуйста, выполните вход в свой аккаунт ещё раз.";
        public string SomeFilesMissingMessage { get; set; } = "Похоже, вы впервые используете этот лаунчер.\nК сожалению, некоторые необходимые файлы отсутствуют и они не могут быть загружены без подключения к Интернету.\nПожалуйста, проверьте свои настройки Сети и перезапустите лаунчер.";

        #endregion

        #region ProfileForm

        #region GroupBoxes

        public string MainProfileSettingsGroup { get; set; } = "Главные настройки профиля";
        public string VersionSettingsGroup { get; set; } = "Выбор версии";
        public string JavaSettingsGroup { get; set; } = "Настройки Java";

        #endregion

        #region Main Settings

        public string ProfileName { get; set; } = "Название профиля:";
        public string WorkingDirectory { get; set; } = "Рабочая директория:";
        public string WindowResolution { get; set; } = "Разрешение окна:";
        public string ActionAfterLaunch { get; set; } = "Действие после запуска:";
        public string KeepLauncherOpen { get; set; } = "Оставить лаунчер открытым";
        public string HideLauncher { get; set; } = "Скрыть лаунчер";
        public string CloseLauncher { get; set; } = "Закрыть лаунчер";
        public string Autoconnect { get; set; } = "Автоподключение:";

        #endregion

        #region Version Selection

        public string Snapshots { get; set; } = "Отображать экспериментальные сборки (\"snapshots\")";
        public string Beta { get; set; } = "Отображать \"Beta\" сборки (2011-2012 гг.)";
        public string Alpha { get; set; } = "Отображать \"Alpha\" сборки (до 2011 г.)";
        public string Other { get; set; } = "Отображать сторонние сборки (Forge, LiteLoader, etc.)";
        public string UseLatestVersion { get; set; } = "Использовать последнюю сборку '{0}'";

        #endregion

        #region Java Options

        public string JavaExecutable { get; set; } = "Исполняемый файл:";
        public string JavaFlags { get; set; } = "Флаги JVM:";

        #endregion

        public string OpenDirectory { get; set; } = "Открыть раб. директорию";

        public string JavaDetectionFailed { get; set; } =
            "Не удалось определить путь до Java! Пожалуйста, укажите путь к исполняемому файлу вручную.";

        #endregion

        #region UsersForm

        public string AddNewUserBox { get; set; } = "Добавление нового пользователя";
        public string Nickname { get; set; } = "Ник/Логин:";
        public string LicenseQuestion { get; set; } = "У вас лицензионный аккаунт?";
        public string Password { get; set; } = "Пароль:";
        public string AddNewUserButton { get; set; } = "Добавить нового пользователя";
        public string RemoveSelectedUser { get; set; } = "Удалить выбранного пользователя";
        public string IncorrectLoginOrPassword { get; set; } = "Логин и/или пароль введены неверно!";
        public string PleaseWait { get; set; } = "Пожалуйста, подождите";

        #endregion

        #region UpdateForm

        public string GoToGitHub { get; set; } = "Перейти на GitHub";
        public string SupportDeveloper { get; set; } = "Поддержать разработчика";

        #endregion

        public string Error { get; set; } = "Ошибка";
        public string Cancel { get; set; } = "Отмена";
        public string Close { get; set; } = "Закрыть";
        public string Save { get; set; } = "Сохранить";
    }
}
