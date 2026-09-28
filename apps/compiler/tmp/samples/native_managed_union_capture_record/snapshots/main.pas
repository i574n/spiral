program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array0 = array of LongInt;
  Tuple9000 = record
    v0: LongInt;
    v1: AnsiString;
    v2: Array0;
  end;
  ClosureValue1 = record
    v0: Tuple9000;
  end;
  ClosureValue0 = record
  end;

function ArrayCreate0(len: LongInt; init_at_zero: Boolean): Array0;
begin
  if len < 0 then raise ERangeError.Create('negative Spiral array length');
  SetLength(Result, len);
  if not init_at_zero then begin end;
end;
procedure DynamicArraySet0(var data: Array0; index: LongInt; value: LongInt);
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  data[index] := value;
end;
function DynamicArrayGet0(const data: Array0; index: LongInt): LongInt;
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  Result := data[index];
end;
function DynamicArrayLen0(const data: Array0): LongInt;
begin
  Result := Length(data);
end;
procedure DynamicArrayClone0(const data: Array0);
begin
end;
procedure DynamicArrayDrop0(var data: Array0);
begin
  SetLength(data, 0);
end;

function TupleCreate9000(v0: LongInt; v1: AnsiString; v2: Array0): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
  Result.v2 := v2;
end;

function ClosureValueCreate1(v0: Tuple9000): ClosureValue1;
begin
  Result.v0 := v0;
end;

function ClosureValueCreate0(): ClosureValue0;
begin
end;

function ClosureInvoke1(x: ClosureValue1; v1: LongInt): LongInt;
var
  v0: Tuple9000;
  v12: LongInt;
  v2: AnsiString;
  v3: Array0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v13: LongInt;
begin
  v0 := x.v0;
  if (v0.v0 = 0) then begin
    v12 := 3;
  end else begin
    v2 := v0.v1;
    v3 := v0.v2;
    DynamicArrayClone0(v3);
    v4 := Length(v2);
    v5 := DynamicArrayLen0(v3);
    v6 := (v4 + v5);
    v7 := DynamicArrayGet0(v3, 0);
    v8 := (v6 + v7);
    v9 := DynamicArrayGet0(v3, 1);
    DynamicArrayDrop0(v3);
    v10 := (v8 + v9);
    v12 := v10;
  end;
  v13 := (v12 + v1);
  Exit(v13);
end;

function ClosureInvoke0(_x: ClosureValue0; v0: LongInt): ClosureValue1;
var
  v1: Array0;
  v2: LongInt;
  v3: Boolean;
  v7: Tuple9000;
  v5: AnsiString;
begin
  v1 := ArrayCreate0(2, False);
  DynamicArraySet0(v1, 0, v0);
  v2 := (v0 + 1);
  DynamicArraySet0(v1, 1, v2);
  v3 := (v0 = 0);
  if v3 then begin
    v7 := TupleCreate9000(0, '', ArrayCreate0(0, False));
  end else begin
    v5 := 'hi';
    DynamicArrayClone0(v1);
    v7 := TupleCreate9000(1, v5, v1);
  end;
  DynamicArrayDrop0(v1);
  Exit(ClosureValueCreate1(v7));
end;

function method0(v0: ClosureValue0): ClosureValue1;
begin
  Exit(ClosureInvoke0(v0, 0));
end;

function method1(v0: ClosureValue0): ClosureValue1;
begin
  Exit(ClosureInvoke0(v0, 4));
end;

function method4(v0: ClosureValue1): LongInt;
var
  v1: LongInt;
  v2: LongInt;
begin
  v1 := ClosureInvoke1(v0, 2);
  v2 := (v1 + 5);
  Exit(v2);
end;

function method3(v0: ClosureValue1): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v1 := ClosureInvoke1(v0, 1);
  v2 := method4(v0);
  v3 := (v1 + v2);
  Exit(v3);
end;

function method2(v0: ClosureValue1; v1: ClosureValue1): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v2 := ClosureInvoke1(v0, 5);
  v3 := method3(v1);
  v4 := (v2 + v3);
  Exit(v4);
end;

function SpiralMain: LongInt;
var
  v0: ClosureValue0;
  v1: ClosureValue1;
  v2: ClosureValue1;
begin
  v0 := ClosureValueCreate0();
  v1 := method0(v0);
  v2 := method1(v0);
  Exit(method2(v1, v2));
end;

begin
  Halt(SpiralMain);
end.
