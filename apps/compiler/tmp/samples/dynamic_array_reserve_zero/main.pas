program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
procedure method0(v0: TArray0); forward;
function method1(v0: TArray0): LongInt; forward;
procedure method2(v0: TArray0); forward;
function method3(v0: TArray0): LongInt; forward;
procedure method4(v0: TArray0); forward;
procedure method5(v0: TArray0); forward;
procedure method6(v0: TArray0); forward;
procedure method0(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 3;
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
  DynamicArrayResize0(v0,v1);
end;
procedure method5(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 0;
  DynamicArrayResize0(v0,v1);
end;
procedure method6(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 3;
  DynamicArrayResize0(v0,v1);
end;
function SpiralMain: LongInt;
var
  v0: TArray0;
  tmp1: TArray0;
  v1: LongInt;
  v2: Boolean;
  v3: LongInt;
  v4: Boolean;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: LongInt;
begin
  tmp1 := nil;
  SetLength(tmp1, 0);
  v0 := tmp1;
  method0(v0);
  v1 := method1(v0);
  v2 := v1 < 3;
  if v2 then begin
      Result := 10;
  end else begin
      method2(v0);
      v3 := method3(v0);
      v4 := v3 = v1;
      if v4 then begin
          method4(v0);
          v0[0] := 4;
          v0[1] := 5;
          v0[2] := 6;
          method5(v0);
          method6(v0);
          v5 := LongInt(Length(v0));
          v6 := v0[0];
          v7 := v5 + v6;
          v8 := v0[1];
          v9 := v7 + v8;
          v10 := v0[2];
          v11 := v9 + v10;
          v12 := v11 - 3;
          Result := v12;
      end else begin
          Result := 11;
      end;
  end;
end;
begin
  Halt(SpiralMain);
end.
