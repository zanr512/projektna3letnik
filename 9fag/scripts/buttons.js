function upvotebutton()
{
    var image = document.getElementById('upvote');
    
    if (image.src.match("upvoteoff"))
    {
        image.src = "images/upvoteon.png";
    }
    else
    {
        image.src = "images/upvoteoff.png";
    }
}

function downvotebutton()
{
    var image = document.getElementById('downvote');

    if (image.src.match("downvoteoff"))
    {
        image.src = "images/downvoteon.png";
    }
    else
    {
        image.src = "images/downvoteoff.png";
    }
}
