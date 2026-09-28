program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  TUS0 = record tag: LongInt; c1_0: TArray0; end;
procedure method0(v0: TArray0); forward;
function method1(v0: TArray0): LongInt; forward;
procedure method2(v0: TArray0); forward;
function method3(v0: TArray0): LongInt; forward;
procedure method4(v0: TArray0); forward;
function method5(v0: TArray0): LongInt; forward;
procedure method6(v0: TArray0); forward;
function method7(v0: TArray0): LongInt; forward;
procedure method8(v0: TArray0); forward;
function method9(v0: TArray0): LongInt; forward;
function method10(v0: TArray0): LongInt; forward;
function method13(v0: TArray0): LongInt; forward;
function method12(v0: TArray0): LongInt; forward;
function method11(v0: TUS0): LongInt; forward;
function method14(v0: TArray0): LongInt; forward;
procedure method0(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 1;
  DynamicArrayReserve0(v0,v1);
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
  v1 := 2;
  DynamicArrayReserve0(v0,v1);
end;
function method3(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  Result := v1;
end;
procedure method4(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 3;
  DynamicArrayReserve0(v0,v1);
end;
function method5(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  Result := v1;
end;
procedure method6(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 5;
  DynamicArrayReserve0(v0,v1);
end;
function method7(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  Result := v1;
end;
procedure method8(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 9;
  DynamicArrayReserve0(v0,v1);
end;
function method9(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  Result := v1;
end;
function method10(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayRefCount0(v0);
  Result := v1;
end;
function US0_0: TUS0;
begin
  Result.tag := 0; 
end;
function US0_1(a0: TArray0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function method13(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayRefCount0(v0);
  Result := v1;
end;
function method12(v0: TArray0): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v1 := DynamicArrayCapacity0(v0);
  v2 := method13(v0);
  v3 := v1 + v2;
  Result := v3;
end;
function method11(v0: TUS0): LongInt;
var
  v1: TArray0;
begin
  case v0.tag of
      0: begin // Empty
          Result := 70;
      end;
      1: begin // Values
          v1 := v0.c1_0;
          Result := method12(v1);
      end;
  end;
end;
function method14(v0: TArray0): LongInt;
var
  v1: LongInt;
begin
  v1 := DynamicArrayRefCount0(v0);
  Result := v1;
end;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: TUS0;
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
  v19: LongInt;
  v20: LongInt;
  v21: LongInt;
  v22: LongInt;
  v23: LongInt;
  v24: LongInt;
begin
  tmp1 := nil;
  SetLength(tmp1, 0);
  v0 := tmp1;
  method0(v0);
  v1 := method1(v0);
  method2(v0);
  v2 := method3(v0);
  method4(v0);
  v3 := method5(v0);
  method6(v0);
  v4 := method7(v0);
  method8(v0);
  v5 := method9(v0);
  v6 := method10(v0);
  v7 := US0_1(v0);
  v8 := method11(v7);
  v9 := method14(v0);
  v10 := v1 - 1;
  v11 := v2 - 2;
  v12 := v10 + v11;
  v13 := v3 - 4;
  v14 := v12 + v13;
  v15 := v4 - 8;
  v16 := v14 + v15;
  v17 := v5 - 16;
  v18 := v16 + v17;
  v19 := v6 - 2;
  v20 := v18 + v19;
  v21 := v8 - 20;
  v22 := v20 + v21;
  v23 := v9 - 2;
  v24 := v22 + v23;
  Result := v24;
end;
begin
  Halt(SpiralMain);
end.
