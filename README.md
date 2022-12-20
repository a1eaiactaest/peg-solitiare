# Peg Solitiare

CS mid-term project. The idea is to design and implement visually representable [peg solitiare](https://en.wikipedia.org/wiki/Peg_solitaire) game.
Additional task is to create a backtracking algorithm in order to find the shortest peg solitiare solution.
There are multiple approaches to this problem, involving depth-first search, A* search.


## Plan

* ~~Draw the board, cross-shaped~~.
* ~~Draw the pegs, leave middle empty~~.
* ~~Implement a `Move()` function.~~
* ~~Redraw board to suit prior `Move()` instance (remove captured peg).~~
* ~~Add illegal move detection to `Move()` function.~~
* ~~Count all the moves.~~
* Detect if there's no moves left.

Those are the basic tasks, further will implement backtracking algorithm to find the shortest peg solitiare solution.


## Notes on Backtracking
Reading George I. Bell [whitepaper](https://arxiv.org/abs/0903.3696) on solving peg solitiare.

One can represent begining state of the game with an $N$ bit integer as so:
```math
2^N - 2^\frac{N}{2} - 1
```
where $N$ is $33$.

So the begining state is:
```math
111111111111111101111111111111111_2
```


