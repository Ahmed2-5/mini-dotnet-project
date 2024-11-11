using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var app = WebApplication.Create();

// Main page with a form
app.MapGet("/", async context =>
{
    await context.Response.WriteAsync(@"
        <html>
            <head>
                <title>Welcome Page</title>
                <style>
                    body { font-family: Arial, sans-serif; text-align: center; margin-top: 50px; }
                    h1 { color: #4CAF50; }
                    form { margin-top: 20px; }
                    input[type='text'], input[type='submit'] {
                        padding: 10px;
                        font-size: 16px;
                        margin: 5px;
                    }
                    input[type='submit'] {
                        background-color: #4CAF50;
                        color: white;
                        border: none;
                        cursor: pointer;
                    }
                    input[type='submit']:hover {
                        background-color: #45a049;
                    }
                </style>
            </head>
            <body>
                <h1>Hello, World!</h1>
                <p>Welcome to this slightly more complex page.</p>
                <p>Enter your name below:</p>
                <form method='get' action='/greet'>
                    <input type='text' name='name' placeholder='Your name' required />
                    <input type='submit' value='Greet Me' />
                </form>
            </body>
        </html>
    ");
});

// Greeting page to display personalized message
app.MapGet("/greet", async context =>
{
    string name = context.Request.Query["name"];
    if (string.IsNullOrEmpty(name))
    {
        name = "Stranger";
    }

    await context.Response.WriteAsync($@"
        <html>
            <head>
                <title>Greeting Page</title>
                <style>
                    body {{font-family: Arial, sans-serif; text-align: center; margin-top: 50px; }}
                    h1 {{color: #4CAF50;}}
                    a {{text-decoration: none; color: #4CAF50; font-weight: bold; }}
                    a:hover {{ color: #45a049; }}
                </style>
            </head>
            <body>
                <h1>Hello, {name}!</h1>
                <p>Thanks for visiting this page.</p>
                <p><a href='/'>Go back to the main page</a></p>
            </body>
        </html>
    ");
});

app.Run();
