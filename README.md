# Peg Solitiare

CS mid-term project. The idea is to design and implement visually representable [peg solitiare](https://en.wikipedia.org/wiki/Peg_solitaire) game.
Additional task is to create a backtracking algorithm in order to find the shortest peg solitiare solution.
There are multiple approaches to this problem, involving depth-first search, A* search.


## Plan

* Draw the board, cross-shaped.
* Draw the pegs, leave middle empty.
* Implement a `Move()` function.
* Redraw board to suit prior `Move()` instance (remove captured peg).
* Add illegal move detection to `Move()` function.
* Count all the moves.
* Detect if there's no moves left.

Those are the basic tasks, further will implement backtracking algorithm to find the shortest peg solitiare solution.
