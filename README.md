# adding-machine

This is a Windows application that emulates a classic _adding machine,_ a
special kind of calculator designed specifically for adding large sets of
numeric values.

As such, its behavior is a little different compared to its more familiar
cousins: each press of the "+" key _accumulates_ a sum, and it only shows that
sum when the "Total" key is pressed.

| Key press     | Calculator behavior          | Adding machine behavior  |
| ---------     | -------------------          | ------------------------ |
| (digits)      | Shows value entered          | Shows value entered      |
| +             | Waits for next value         | Adds value to sum        |
| (more digits) | Shows new value              | Shows new value          |
| =             | Computes sum and displays it | Adds value to sum        |
| Total         | (no equivalent)              | Shows sum                |

In this emulation, the "+" and "=" are the same "add" key, and Enter is the
"total" key.  The buttons are arranged in the same pattern as the 10-key portion
of a Windows keyboard.  Here's what it looks like:

![Screen shot](Design/Screen%20shot.jpg)

While you can click on the buttons to enter values and operations, this
application lets you use the keyboard for rapid entry.

Notice that the "&divide;" key is in the same place as the "/" in the 10-key
portion of your keyboard, and the "&times;" key is in the same place as the "*"
key.  The "ST/GT" (subtotal/grand total) button is the Enter key.

(Unfortunately, the NumLock key can't easily be used as the "clear/clear entry"
button; so you must use the Esc key instead to clear a value.)

You can perform multiplication and division using this application, but keep in
mind that the result of that calculation isn't added to the sum until you press
the "+" key.

## Why use an adding machine?

What makes an adding machine more useful than a regular calculator is the paper
tape recording the values and operations.  Most physical calculators won't have
paper tape, and while the Windows calculator _can_ show you the computing
history, it's a little cumbersome.

This application emulates a paper tape holding the values and operations.
Subtractions and negative results are shown in dark red text.  And the tape is
retained each time you open the application (unless you turn this off in the
options).  You can also save the tape to a file and load it again if desired.

If you need a value that's recorded on the tape, all you need to do is
double-click on it to re-enter that value.

## Why not use Excel instead?

Excel can do everything this application can do, and much, much more.  But this
application is designed to be very lightweight, and if all you need to do is add
a column of numbers, you might find this to be a quicker and more efficient tool
for the job.




