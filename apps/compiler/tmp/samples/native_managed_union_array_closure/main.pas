program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array0 = array of LongInt;
  Tuple9000 = record
    v0: LongInt;
    v1: Array0;
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

function TupleCreate9000(v0: LongInt; v1: Array0): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
end;

function ClosureValueCreate0(): ClosureValue0;
begin
end;

function ClosureInvoke0(_x: ClosureValue0; v0: LongInt): Tuple9000;
var
  v1: Boolean;
  v3: Array0;
  v4: LongInt;
begin
  v1 := (v0 = 0);
  if v1 then begin
    Exit(TupleCreate9000(0, ArrayCreate0(0, False)));
  end else begin
    v3 := ArrayCreate0(2, False);
    DynamicArraySet0(v3, 0, v0);
    v4 := (v0 + 1);
    DynamicArraySet0(v3, 1, v4);
    Exit(TupleCreate9000(1, v3));
  end;
end;

function method0(v0: ClosureValue0): Tuple9000;
begin
  Exit(ClosureInvoke0(v0, 0));
end;

function score1(v0: Tuple9000): LongInt;
var
  v1: Array0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  if (v0.v0 = 0) then begin
    if (v0.v0 = 1) then begin
      DynamicArrayDrop0(v0.v1);
    end;
    Exit(3);
  end else begin
    v1 := v0.v1;
    DynamicArrayClone0(v1);
    if (v0.v0 = 1) then begin
      DynamicArrayDrop0(v0.v1);
    end;
    v2 := DynamicArrayLen0(v1);
    v3 := DynamicArrayGet0(v1, 0);
    v4 := (v2 + v3);
    v5 := DynamicArrayGet0(v1, 1);
    DynamicArrayDrop0(v1);
    v6 := (v4 + v5);
    Exit(v6);
  end;
end;

function method2(v0: ClosureValue0): Tuple9000;
begin
  Exit(ClosureInvoke0(v0, 4));
end;

function SpiralMain: LongInt;
var
  v0: ClosureValue0;
  v1: Tuple9000;
  v2: LongInt;
  v3: Tuple9000;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := ClosureValueCreate0();
  v1 := method0(v0);
  if (v1.v0 = 1) then begin
    DynamicArrayClone0(v1.v1);
  end;
  v2 := score1(v1);
  if (v1.v0 = 1) then begin
    DynamicArrayDrop0(v1.v1);
  end;
  v3 := method2(v0);
  if (v3.v0 = 1) then begin
    DynamicArrayClone0(v3.v1);
  end;
  v4 := score1(v3);
  if (v3.v0 = 1) then begin
    DynamicArrayDrop0(v3.v1);
  end;
  v5 := (v2 + v4);
  v6 := (v5 + 28);
  Exit(v6);
end;

begin
  Halt(SpiralMain);
end.
