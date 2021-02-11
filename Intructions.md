# Instructions.

| InstructionId |Name | Description |
| ------ | ------ | ----------- |
| 0  | SET | Set a registry to a given value.
| 1  | COPY | Copy a registry into another. `copy a b` will do `a <- b`.
| 2  | EQ | Compare `ARG1` and `ARG2`. If equals, set `RES` to 1, else to 0.
| 3  | GT | Check if `ARG1` > `ARG2`. If true, set `RES` to 1, else to 0.
| 4  | LT | Check if `ARG1` < `ARG2`. If true, set `RES` to 1, else to 0.
| 5  | BRANCH | If `RES` = 1, jump to the line `ARG1` else do nothing.
| 6  | JUMP | Jump to the line `ARG1`.
| 7  | OR | Set `RES` to `ARG1` OR `ARG2`.
| 8  | XOR | Set `RES` to `ARG1` XOR `ARG2`.
| 9  | AND | Set `RES` to `ARG1` AND `ARG2`.
| A  | SUM | Set `RES` to `ARG1` + `ARG2`.
| B  | SUB | Set `RES` to `ARG1` - `ARG2`.
| C  | MUL | Set `RES` to `ARG1` * `ARG2`.
| D  | DIV | Set `RES` to `ARG1` / `ARG2`.
| E  | LSHIFT | Set `RES` to `ARG1` << `ARG2`.
| F  | RSHIFT | Set `RES` to `ARG1` >> `ARG2`.
