using Domain;
using Infrastructure;

UserService userService = new UserService();
PostService postService = new PostService();
CommentService commentService = new CommentService();
LikeService likeService = new LikeService();

while (true)
{
    Console.WriteLine("\n1. Add User");
    Console.WriteLine("2. Show Users");
    Console.WriteLine("3. Add Post");
    Console.WriteLine("4. Add Comment");
    Console.WriteLine("5. Add Like");
    Console.WriteLine("0. Exit");

    var choice = Console.ReadLine();

    if (choice == "0") break;

    switch (choice)
    {
        case "1":
            var user = new User();

            Console.Write("Username: ");
            user.Username = Console.ReadLine()!;

            Console.Write("Email: ");
            user.Email = Console.ReadLine()!;

            Console.Write("FullName: ");
            user.FullName = Console.ReadLine()!;

            user.RegistrationDate = DateTime.Now;

            userService.Add(user);
            break;

        case "2":
            var users = userService.GetAll();

            foreach (var u in users)
                Console.WriteLine($"{u.UserId} | {u.Username} | {u.Email}");
            break;

        case "3":
            var post = new Post();

            Console.Write("UserId: ");
            post.UserId = int.Parse(Console.ReadLine()!);

            Console.Write("Content: ");
            post.Content = Console.ReadLine()!;

            post.CreationDate = DateTime.Now;
            post.LikesCount = 0;

            postService.Add(post);
            break;

        case "4":
            var comment = new Comment();

            Console.Write("UserId: ");
            comment.UserId = int.Parse(Console.ReadLine()!);

            Console.Write("PostId: ");
            comment.PostId = int.Parse(Console.ReadLine()!);

            Console.Write("Content: ");
            comment.Content = Console.ReadLine()!;

            comment.CreationDate = DateTime.Now;

            commentService.Add(comment);
            break;

        case "5":
            var like = new Like();

            Console.Write("UserId: ");
            like.UserId = int.Parse(Console.ReadLine()!);

            Console.Write("PostId: ");
            like.PostId = int.Parse(Console.ReadLine()!);

            like.LikeDate = DateTime.Now;

            likeService.Add(like);
            break;
    }
}