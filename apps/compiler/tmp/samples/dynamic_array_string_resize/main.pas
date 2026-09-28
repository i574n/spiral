program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TArray0 = array of AnsiString;
procedure method0(v0: TArray0); forward;
procedure method1(v0: TArray0); forward;
procedure method2(v0: TArray0); forward;
function method3(v0: TArray0): LongInt; forward;
function method4(v0: TArray0): LongInt; forward;
procedure method5(v0: TArray0); forward;
procedure method0(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 1;
  DynamicArrayResize0(v0,v1);
end;
procedure method1(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 8;
  DynamicArrayReserve0(v0,v1);
end;
procedure method2(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 3;
  DynamicArrayResize0(v0,v1);
end;
function method3(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayRefCount0(v0);
  Result := v1;
end;
function method4(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  Result := v1;
end;
procedure method5(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 1;
  DynamicArrayResize0(v0,v1);
end;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
  v13: LongInt;
  v14: LongInt;
  v15: LongInt;
  v16: LongInt;
  v17: LongInt;
  v18: LongInt;
begin
  tmp1 := nil;
  SetLength(tmp1, 4);
  v0 := tmp1;
  method0(v0);
  v1 := 'ab';
  v0[0] := v1;
  method1(v0);
  method2(v0);
  v2 := 'cde';
  v0[1] := v2;
  v3 := 'f';
  v0[2] := v3;
  v4 := v0[0];
  v5 := v0[1];
  v6 := v0[2];
  v7 := method3(v0);
  v8 := method4(v0);
  method5(v0);
  v9 := LongInt(Length(v4));
  v10 := LongInt(Length(v5));
  v11 := v9 + v10;
  v12 := LongInt(Length(v6));
  v13 := v11 + v12;
  v14 := v13 + v7;
  v15 := v14 + v8;
  v16 := LongInt(Length(v0));
  v17 := v15 + v16;
  v18 := v17 - 17;
  Result := v18;
end;
begin
  Halt(SpiralMain);
end.
