using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsService
{
    public class Result
    {
        public int id { get; set; }
        //public SourcePost source_post { get; set; }
        //public object last_response { get; set; }
        //public object blocked_by { get; set; }
        //public List<ClientReference> client_reference { get; set; }
        //public bool read_only { get; set; }
        public LastPublishedPost last_published_post { get; set; }
        //public List<object> comments { get; set; }
        //public AssignedUserInfo assigned_user_info { get; set; }
        //public object address { get; set; }
        //public object address_id { get; set; }
        //public bool is_read { get; set; }
        //public bool is_deleted { get; set; }
        //public int temp_report_id { get; set; }
        //public DateTime term { get; set; }
        //public int current_stage { get; set; }
        //public DateTime current_stage_term { get; set; }
        //public DateTime current_stage_start_timestamp { get; set; }
        //public object end_stage_timestamp { get; set; }
        //public AdditionalParameters additional_parameters { get; set; }
        //public List<object> tags { get; set; }
        //public DateTime created { get; set; }
        //public DateTime updated { get; set; }
        //public bool auto_add_rel_posts { get; set; }
        //public int new_posts_count { get; set; }
        //public bool send_feedback { get; set; }
        //public bool shall_create_tmp_mlgreport { get; set; }
        public int number { get; set; }
        //public Extra extra { get; set; }
        //public int bind_type { get; set; }
        //public object is_in_time { get; set; }
        //public DateTime response_deadline { get; set; }
        //public bool attachment_in_post_exists { get; set; }
        //public bool attachment_in_response_exists { get; set; }
        //public int source_post_social_account_inner_id { get; set; }
        //public string source_post_social_network_id { get; set; }
        //public int client { get; set; }
        //public int author { get; set; }
        //public int report { get; set; }
        //public int assigned_user { get; set; }
        //public int location { get; set; }
        //public object organization { get; set; }
        //public int category { get; set; }
        //public object subcategory { get; set; }
        //public int priority { get; set; }
        //public object close_reason { get; set; }
    }
    public class AdditionalParameters
    {
    }
    public class AssignedUserInfo
    {
        public int id { get; set; }
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public object avatar { get; set; }
        public bool is_deleted { get; set; }
        public int status { get; set; }
    }
    public class Author
    {
        public int id { get; set; }
        public MetaAuthor meta_author { get; set; }
        public long external_id { get; set; }
        public int subscribers { get; set; }
        public bool is_deleted { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public object description { get; set; }
        public string image_url { get; set; }
        public string url { get; set; }
        public bool ignore { get; set; }
        public DateTime updated { get; set; }
        public GeoTags geo_tags { get; set; }
        public Coordinates coordinates { get; set; }
        public object first_name { get; set; }
        public object last_name { get; set; }
        public object image_file { get; set; }
        public int blog { get; set; }
        public long? location { get; set; }
        public int author_id { get; set; }
        public string social_name { get; set; }
        public string network_code { get; set; }
        public bool @checked { get; set; }
    }
    public class Blog
    {
        public int id { get; set; }
        public string host_name { get; set; }
        public string network_code { get; set; }
        public string url { get; set; }
        public bool is_deleted { get; set; }
        public int host_type { get; set; }
        public long external_id { get; set; }
        public string title { get; set; }
        public string host { get; set; }
    }
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class ClientReference
    {
        public int id { get; set; }
        public int title_id { get; set; }
    }
    public class Coordinates
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class Extra
    {
        public bool spam { get; set; }
        public List<StateHistory> state_history { get; set; }
        public string vk_post_source { get; set; }
        public object external_report { get; set; }
        public double relevance_scores { get; set; }
        public IncidentBindings incident_bindings { get; set; }
        public int? social_account_id { get; set; }
        public string social_network_id { get; set; }
        public double raw_relevance_scores { get; set; }
        public int social_account_inner_id { get; set; }
        public string social_account_inner_name { get; set; }
        public string social_account_network_url { get; set; }
        public ManuallyAttachmentExists manually_attachment_exists { get; set; }
    }
    public class GeoTags
    {
        public City city { get; set; }
        public Region region { get; set; }
        public Country country { get; set; }
    }
    public class IncidentBindings
    {
    }
    public class LastIncident
    {
        public int id { get; set; }
        public DateTime created { get; set; }
        public int number { get; set; }
    }
    public class LastPublishedPost
    {
        public int id { get; set; }
        public string group { get; set; }
        public long external_id { get; set; }
        public List<object> images { get; set; }
        //public Extra extra { get; set; }
        public bool is_blocked { get; set; }
        public object blocked_by { get; set; }
        public Author author { get; set; }
        public Blog blog { get; set; }
        public object report_theme { get; set; }
        public string location_name { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int post_subscribers_count { get; set; }
        public object post_involvement { get; set; }
        public object post_tonality { get; set; }
        public DateTime publish_date { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string url { get; set; }
        public string parent_url { get; set; }
        public int message_type { get; set; }
        public object _social_network_code { get; set; }
        public object hash { get; set; }
        public int state { get; set; }
        public bool remove_similar { get; set; }
        public object post_binding_datetime { get; set; }
        public object deleted_as_spam_date { get; set; }
        public bool? response_no_received_from_relevance_service { get; set; }
        public int client { get; set; }
        public object report { get; set; }
        //public int location { get; set; }
        public int incident { get; set; }
        public object delete_reason { get; set; }
    }
    public class ManuallyAttachmentExists
    {
    }
    public class MetaAuthor
    {
        public int id { get; set; }
        public string gender { get; set; }
        public string friend_count { get; set; }
        public string follower_count { get; set; }
        public object birth_city_name { get; set; }
        public string city_name { get; set; }
        public object activities_work { get; set; }
        public string education_level { get; set; }
        public object activities_school { get; set; }
        public object activities_university { get; set; }
        public LastIncident last_incident { get; set; }
        public List<object> client_reference { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
        public object description { get; set; }
        public int subscribers_count { get; set; }
        public int posts_count { get; set; }
        public int incidents_count { get; set; }
        public bool ignore { get; set; }
        public bool editable { get; set; }
        public AdditionalParameters additional_parameters { get; set; }
        public GeoTags geo_tags { get; set; }
        public Coordinates coordinates { get; set; }
        public bool editable_geo_info { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int? birth_day { get; set; }
        public int? birth_month { get; set; }
        public int? birth_year { get; set; }
        public int category { get; set; }
        public int main_author { get; set; }
        public long? location { get; set; }
    }
    public class Region
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class Root
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    }
    public class SourcePost
    {
        public int id { get; set; }
        public string group { get; set; }
        public int external_id { get; set; }
        public List<object> images { get; set; }
        public Extra extra { get; set; }
        public bool is_blocked { get; set; }
        public object blocked_by { get; set; }
        public Author author { get; set; }
        public Blog blog { get; set; }
        public object report_theme { get; set; }
        public string location_name { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int post_subscribers_count { get; set; }
        public object post_involvement { get; set; }
        public object post_tonality { get; set; }
        public DateTime publish_date { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string url { get; set; }
        public string parent_url { get; set; }
        public int message_type { get; set; }
        public object _social_network_code { get; set; }
        public object hash { get; set; }
        public int state { get; set; }
        public bool remove_similar { get; set; }
        public object post_binding_datetime { get; set; }
        public object deleted_as_spam_date { get; set; }
        public bool response_no_received_from_relevance_service { get; set; }
        public int client { get; set; }
        public object report { get; set; }
        public int location { get; set; }
        public int incident { get; set; }
        public object delete_reason { get; set; }
    }
    public class StateHistory
    {
        public int to { get; set; }
        public int from { get; set; }
        public int user { get; set; }
        public DateTime timestamp { get; set; }
    }
}
