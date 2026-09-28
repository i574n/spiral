program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TArray0 = array of AnsiString;
  TUS0 = record tag: LongInt; c1_0: TArray0; end;
procedure method0(v0: TArray0); forward;
function method2(v0: TArray0): LongInt; forward;
procedure method3(v0: TArray0); forward;
procedure method4(v0: TArray0); forward;
procedure method5(v0: TArray0); forward;
function method1(v0: TUS0): LongInt; forward;
function method6(v0: TUS0): LongInt; forward;
procedure method7(v0: TArray0); forward;
procedure method8(v0: TArray0); forward;
procedure method0(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 1;
  DynamicArrayResize0(v0,v1);
end;
function US0_0: TUS0;
begin
  Result.tag := 0; 
end;
function US0_1(a0: TArray0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function method2(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  Result := v1;
end;
procedure method3(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 8;
  DynamicArrayReserve0(v0,v1);
end;
procedure method4(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 3;
  DynamicArrayResize0(v0,v1);
end;
procedure method5(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 2;
  DynamicArrayResize0(v0,v1);
end;
function method1(v0: TUS0): LongInt;
var
  v1: TArray0;
  v2: AnsiString;
  v3: AnsiString;
begin
  case v0.tag of
      0: begin // Empty
          Result := 90;
      end;
      1: begin // Values
          v1 := v0.c1_0;
          method3(v1);
          method4(v1);
          v2 := 'cde';
          v1[1] := v2;
          v3 := 'f';
          v1[2] := v3;
          method5(v1);
          Result := method2(v1);
      end;
  end;
end;
function method6(v0: TUS0): LongInt;
var
  v1: TArray0;
  v2: LongInt;
  v3: AnsiString;
  v4: LongInt;
  v5: LongInt;
  v6: AnsiString;
  v7: LongInt;
  v8: LongInt;
begin
  case v0.tag of
      0: begin // Empty
          Result := 91;
      end;
      1: begin // Values
          v1 := v0.c1_0;
          v2 := LongInt(Length(v1));
          v3 := v1[0];
          v4 := LongInt(Length(v3));
          v5 := v2 + v4;
          v6 := v1[1];
          v7 := LongInt(Length(v6));
          v8 := v5 + v7;
          Result := v8;
      end;
  end;
end;
procedure method7(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 0;
  DynamicArrayResize0(v0,v1);
end;
procedure method8(v0: TArray0);
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
  v2: TUS0;
  v3: LongInt;
  v4: TUS0;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
begin
  tmp1 := nil;
  SetLength(tmp1, 4);
  v0 := tmp1;
  method0(v0);
  v1 := 'ab';
  v0[0] := v1;
  v2 := US0_1(v0);
  v3 := method1(v2);
  v4 := US0_1(v0);
  v5 := method6(v4);
  method7(v0);
  method8(v0);
  v6 := v5 + v3;
  v7 := LongInt(Length(v0));
  v8 := v6 + v7;
  v9 := v8 - 16;
  Result := v9;
end;
begin
  Halt(SpiralMain);
end.
