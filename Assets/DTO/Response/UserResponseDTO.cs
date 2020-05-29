using System;

namespace Assets.DTO.Response
{
    [Serializable]
    public class UserResponseDTO
    {
        // Unity doesn't serialize get, set and complex types, maybe we add [SerializeField] can be serializable.
        public int id;
        public string name;
        public string email;
        public string cpf;  
    }
}
