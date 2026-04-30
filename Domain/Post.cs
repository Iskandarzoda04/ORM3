namespace Domain;

public class Post
{
    public int PostId {get; set;}
    public int UserId {get; set;}
    public string Content {get; set;} = "";
    public DateTime CreationDate {get; set;}
    public int LikesCount {get; set;}
}