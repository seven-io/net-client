using System.Threading.Tasks;
using Newtonsoft.Json;

namespace seven_library.Api.Library
{
    public class ContactsResponse
    {
        [JsonProperty("pagingMetadata")]
        public PagingMetadata PagingMetadata { get; set; }
        
        [JsonProperty("data")]
        public Contact[] Data { get; set; }
    }
    
    public class Contacts {
        private readonly BaseClient _client;
        
        public Contacts(BaseClient client) {
            _client = client;
        }
        
        public async Task<Contact> One(uint id) {
            var response = await _client.Get($"contacts/{id}");

            return JsonConvert.DeserializeObject<Contact>(response);
        }
        
        public async Task<Contact> One(Contact contact)
        {
            return await One(contact.Id);
        }
        
        public async Task<ContactsResponse> All() {
            var response = await _client.Get("contacts");

            return JsonConvert.DeserializeObject<ContactsResponse>(response);
        }
        
        public async Task<Contact> Edit(Contact contact)
        {
            var response = await _client.Patch($"contacts{contact.Id}", contact);

            return JsonConvert.DeserializeObject<Contact>(response);
        }
        
        public async Task<Contact> Create(Contact contact) {
            var response = await _client.Post("contacts", contact);

            return JsonConvert.DeserializeObject<Contact>(response);
        }
        
        public async Task<bool> Delete(uint id) {
            await _client.Delete($"contacts/{id}");

            return true;
        }
        
        public async Task<bool> Delete(Contact contact)
        {
            return await Delete(contact.Id);
        }
    }
    public class Properties
    {
        [JsonProperty("firstname")]
        public string? Firstname { get; set; }
        
        [JsonProperty("lastname")]
        public string? Lastname { get; set; }
              
        [JsonProperty("mobile_number")]
        public string? MobileNumber { get; set; }
        
        [JsonProperty("home_number")]
        public string? HomeNumber { get; set; }
        
        [JsonProperty("email")]
        public string? Email { get; set; }
                
        [JsonProperty("address")]
        public string? Address { get; set; }
                
        [JsonProperty("postal_code")]
        public string? PostalCode { get; set; }
                
        [JsonProperty("city")]
        public string? City { get; set; }
                
        [JsonProperty("birthday")]
        public string? Birthday { get; set; }
                
        [JsonProperty("notes")]
        public string? Notes { get; set; }
    }

    public class Validation
    {
        [JsonProperty("state")]
        public string? State { get; set; }
        
        [JsonProperty("timestamp")]
        public string? Timestamp { get; set; }
    }
    
    public class Metadata
    {
        public Metadata(string color, string initials)
        {
            Color = color;
            Initials = initials;
        }

        [JsonProperty("color")]
        public string Color { get; set; }
        
        [JsonProperty("initials")]
        public string Initials { get; set; }
    }

    public class Contact
    {
        [JsonProperty("avatar")]
        public string? Avatar { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }
        
        [JsonProperty("id")]
        public uint Id { get; set; }
        
        [JsonProperty("initials")]
        public Metadata Initials { get; set; }
        
        [JsonProperty("properties")]
        public Properties Properties { get; set; }
        
        [JsonProperty("validation")]
        public Validation Validation { get; set; }
    }
}