# Here is the memmory organisation.

| Registry Address | Registry Name | Read/Write permissions | Description |
| ------ | ------ | ----------- |----------- |
| 0x0000   | CONTROL | RW | [The description.](ControlRegistry.md)
|0x0001 | ARG1 | W | The first argument beeing used by  mono argument instructions.
|0x0002 | ARG2 | W | The second argument beeing used by double argument instructions.
|0x0003 | RES | R | The registry containing the result of any instruction.
|0x0004 | INOUT | RW | [The description.](InOutRegistry.md)
|0x0005 - 0xFFFF |  | RW | Memmory used by the program.