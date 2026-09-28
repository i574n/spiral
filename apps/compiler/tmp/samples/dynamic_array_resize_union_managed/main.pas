program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  TUS0 = record tag: LongInt; c1_0: TArray0; end;
function method1(v0: TArray0): LongInt; forward;
procedure method2(v0: TArray0); forward;
procedure method3(v0: TArray0); forward;
procedure method4(v0: TArray0); forward;
function method0(v0: TUS0): LongInt; forward;
function method5(v0: TUS0): LongInt; forward;
procedure method6(v0: TArray0); forward;
procedure method7(v0: TArray0); forward;
function US0_0: TUS0;
begin
  Result.tag := 0; 
end;
function US0_1(a0: TArray0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function method1(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  Result := v1;
end;
procedure method2(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 8;
  DynamicArrayReserve0(v0,v1);
end;
procedure method3(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 5;
  DynamicArrayResize0(v0,v1);
end;
procedure method4(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 2;
  DynamicArrayResize0(v0,v1);
end;
function method0(v0: TUS0): LongInt;
var
  v1: TArray0;
begin
  case v0.tag of
      0: begin // Empty
          Result := 90;
      end;
      1: begin // Values
          v1 := v0.c1_0;
          method2(v1);
          method3(v1);
          v1[1] := 11;
          method4(v1);
          Result := method1(v1);
      end;
  end;
end;
function method5(v0: TUS0): LongInt;
var
  v1: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  case v0.tag of
      0: begin // Empty
          Result := 91;
      end;
      1: begin // Values
          v1 := v0.c1_0;
          v2 := LongInt(Length(v1));
          v3 := v1[0];
          v4 := v2 + v3;
          v5 := v1[1];
          v6 := v4 + v5;
          Result := v6;
      end;
  end;
end;
procedure method6(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 0;
  DynamicArrayResize0(v0,v1);
end;
procedure method7(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 2;
  DynamicArrayResize0(v0,v1);
end;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: TUS0;
  v2: LongInt;
  v3: TUS0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
  v13: LongInt;
  v14: LongInt;
begin
  tmp1 := nil;
  SetLength(tmp1, 2);
  v0 := tmp1;
  v0[0] := 7;
  v0[1] := 3;
  v1 := US0_1(v0);
  v2 := method0(v1);
  v3 := US0_1(v0);
  v4 := method5(v3);
  method6(v0);
  method7(v0);
  v5 := DynamicArrayRefCount0(v0);
  v6 := v4 + v2;
  v7 := LongInt(Length(v0));
  v8 := v6 + v7;
  v9 := v0[0];
  v10 := v8 + v9;
  v11 := v0[1];
  v12 := v10 + v11;
  v13 := v12 + v5;
  v14 := v13 - 31;
  Result := v14;
end;
begin
  Halt(SpiralMain);
end.
