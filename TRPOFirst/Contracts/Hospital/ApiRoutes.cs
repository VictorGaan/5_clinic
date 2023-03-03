namespace TRPOFirst.Contracts.Hospital;

public static class ApiRoutes
{
    public const string Root = "api";
    
    public const string Version = "v1";

    public const string Base = Root + "/" + Version;
    
    public static class Hospital
    {
        // Все связанное с Пациентами
        public const string GetAllPacients = Base + "/pacients";
        
        public const string UpdatePacients = Base + "/pacients/{IdPacient}";

        public const string GetPacients = Base + "/pacients/{IdPacient}";
        
        public const string CreatePacients = Base + "/pacients";
        
        // Все связанное с Докторами
        public const string GetAllDoctors = Base + "/doctors";
        
        public const string UpdateDoctor = Base + "/doctors/{idDoctor}";
        
        public const string GetDoctors = Base + "/doctors/{idDoctor}";
        
        public const string CreateDoctors = Base + "/doctors";
        
        // Все связанное с Специальностями
        public const string GetAllPosts = Base + "/posts";
        
        public const string UpdatePosts = Base + "/posts/{idPost}";
        
        public const string GetPosts = Base + "/posts/{idPost}";
        
        public const string CreatePosts = Base + "/posts";
        
        // Все связанно с Первичным осмотром
        public const string GetAllReceptionSchedule = Base + "/receptionSchedule";
        
        public const string UpdateReceptionSchedule = Base + "/receptionSchedule/{idReceptionSchedule}";
        
        public const string GetReceptionSchedule = Base + "/receptionSchedule/{idReceptionSchedule}";
        
        public const string CreateReceptionSchedule = Base + "/receptionSchedule";
        
        // Все связанно с основным осмотром осмотром
        public const string GetAllDoctorsAppointments = Base + "/doctorsAppointments";
        
        public const string UpdateDoctorsAppointments = Base + "/doctorsAppointments/{idDoctorsAppointments}";
        
        public const string GetDoctorsAppointments = Base + "/doctorsAppointments/{idDoctorsAppointments}";
        
        public const string CreateDoctorsAppointments = Base + "/doctorsAppointments";
        
        // Все связанно с основным основоной информацией о докторе
        public const string GetAllDoctorsInfo = Base + "/doctorsInfo";
        
        public const string UpdateDoctorsInfo= Base + "/doctorsInfo/{idDoctorsInfo}";
        
        public const string GetDoctorsInfo = Base + "/doctorsInfo/{idDoctorsInfo}";
        
        public const string CreateDoctorsInfo = Base + "/doctorsInfo";
        
        // Все связанно с --
        public const string GetAllReception = Base + "/reception";
        
        public const string UpdateReception = Base + "/reception/{IdReception}";
        
        public const string GetReception = Base + "/reception/{IdReception}";
        
        public const string CreateReception = Base + "/reception";
        
        // Все связанно с болезнями
        public const string GetAllDiseases = Base + "/diseases";
        
        public const string UpdateDiseases = Base + "/diseases/{IdDiseases}";
        
        public const string GetDiseases = Base + "/diseases/{IdDiseases}";
        
        public const string CreateDiseases = Base + "/diseases";
    }
}