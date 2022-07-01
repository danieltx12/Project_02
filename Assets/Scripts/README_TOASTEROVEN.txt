You're looking for fireweapon.cs which handles both gunfire and grappling. Grappling should be in entirely seperate functions, this should give you an idea
on how to apply force to the rigidbody of your player (which adding a rigidbody will likely break many things with XR plugin but Unity forums and documentation
are really solid, even XR plugin stuff will have answers if you look hard enough and master Google-Fu)

GrappleLine.cs is in the assets folder because I missed moving it to scripts 2 years ago. All it does is basically the math on the player's trajectory and uses
a line renderer to render a line. It's a pretty quick and dirty way to do it, but if you mess with the line settings it will get the job done until you
learn more Unity animation systems to actually have a working grappling hook. You had mentioned being able to retract and detract the line to lower yourself from
ceilings. This can probably be done relatively well by altering the force applied to the rigidbody when certain buttons are pressed. You can also
use code to constrain the rigidbody's Y value to prevent it from bouncing up and down.


Hope this all helps, wish we had more time this week but I enjoyed meeting and working with you. Good luck! :)