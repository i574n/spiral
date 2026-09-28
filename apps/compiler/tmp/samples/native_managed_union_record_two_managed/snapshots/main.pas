program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Array1 = array of LongInt;
  Tuple9000 = record
    v0: LongInt;
    v1: AnsiString;
    v2: Array1;
  end;
  ClosureValue0 = record
  end;

function ArrayCreate1(len: LongInt; init_at_zero: Boolean): Array1;
begin
  if len < 0 then raise ERangeError.Create('negative Spiral array length');
  SetLength(Result, len);
  if not init_at_zero then begin end;
end;
procedure DynamicArraySet1(var data: Array1; index: LongInt; value: LongInt);
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  data[index] := value;
end;
function DynamicArrayGet1(const data: Array1; index: LongInt): LongInt;
begin
  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');
  Result := data[index];
end;
function DynamicArrayLen1(const data: Array1): LongInt;
begin
  Result := Length(data);
end;
procedure DynamicArrayClone1(const data: Array1);
begin
end;
procedure DynamicArrayDrop1(var data: Array1);
begin
  SetLength(data, 0);
end;

function TupleCreate9000(v0: LongInt; v1: AnsiString; v2: Array1): Tuple9000;
begin
  Result.v0 := v0;
  Result.v1 := v1;
  Result.v2 := v2;
end;

function ClosureValueCreate0(): ClosureValue0;
begin
end;

function ClosureInvoke0(_x: ClosureValue0; v0: LongInt): Tuple9000;
var
  v1: Boolean;
  v3: Array1;
  v4: LongInt;
  v5: AnsiString;
begin
  v1 := (v0 = 0);
  if v1 then begin
    Exit(TupleCreate9000(0, '', ArrayCreate1(0, False)));
  end else begin
    v3 := ArrayCreate1(2, False);
    DynamicArraySet1(v3, 0, v0);
    v4 := (v0 + 1);
    DynamicArraySet1(v3, 1, v4);
    v5 := 'hi';
    Exit(TupleCreate9000(1, v5, v3));
  end;
end;

function method0(v0: ClosureValue0): Tuple9000;
begin
  Exit(ClosureInvoke0(v0, 0));
end;

function method1(v0: ClosureValue0): Tuple9000;
begin
  Exit(ClosureInvoke0(v0, 4));
end;

function SpiralMain: LongInt;
var
  v0: ClosureValue0;
  v1: Tuple9000;
  v12: LongInt;
  v2: AnsiString;
  v3: Array1;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v13: Tuple9000;
  v24: LongInt;
  v14: AnsiString;
  v15: Array1;
  v16: LongInt;
  v17: LongInt;
  v18: LongInt;
  v19: LongInt;
  v20: LongInt;
  v21: LongInt;
  v22: LongInt;
  v25: LongInt;
  v26: LongInt;
begin
  v0 := ClosureValueCreate0();
  v1 := method0(v0);
  if (v1.v0 = 0) then begin
    v12 := 3;
  end else begin
    v2 := v1.v1;
    v3 := v1.v2;
    DynamicArrayClone1(v3);
    v4 := Length(v2);
    v5 := DynamicArrayLen1(v3);
    v6 := (v4 + v5);
    v7 := DynamicArrayGet1(v3, 0);
    v8 := (v6 + v7);
    v9 := DynamicArrayGet1(v3, 1);
    DynamicArrayDrop1(v3);
    v10 := (v8 + v9);
    v12 := v10;
  end;
  if (v1.v0 = 1) then begin
    Finalize(v1.v1);
  end;
  if (v1.v0 = 1) then begin
    DynamicArrayDrop1(v1.v2);
  end;
  v13 := method1(v0);
  if (v13.v0 = 0) then begin
    v24 := 3;
  end else begin
    v14 := v13.v1;
    v15 := v13.v2;
    DynamicArrayClone1(v15);
    v16 := Length(v14);
    v17 := DynamicArrayLen1(v15);
    v18 := (v16 + v17);
    v19 := DynamicArrayGet1(v15, 0);
    v20 := (v18 + v19);
    v21 := DynamicArrayGet1(v15, 1);
    DynamicArrayDrop1(v15);
    v22 := (v20 + v21);
    v24 := v22;
  end;
  if (v13.v0 = 1) then begin
    Finalize(v13.v1);
  end;
  if (v13.v0 = 1) then begin
    DynamicArrayDrop1(v13.v2);
  end;
  v25 := (v12 + v24);
  v26 := (v25 + 26);
  Exit(v26);
end;

begin
  Halt(SpiralMain);
end.
