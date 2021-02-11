# The Control Registry.

| Bits |Name | Description |
| ------ | ------ | ----------- |----------- |
| 0  | STOP | If set to 1, It makes the VM exit.
| 1  | PRINT | If set to 1, print the OUT part of the [INOUT](InOutRegistry.md) registry. It will then autoreset.
| 2  | READ | If set to 1, the IN part of the [INOUT](InOutRegistry.md) registry just received something. Need to be manually reseted.