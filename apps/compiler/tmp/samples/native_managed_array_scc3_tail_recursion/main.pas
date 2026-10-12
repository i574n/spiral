program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
procedure method0(v0: TArray0); forward;
function method4(v0: LongInt; v1: TArray0): LongInt; forward;
function method3(v0: LongInt; v1: TArray0): LongInt; forward;
function method2(v0: LongInt; v1: TArray0): LongInt; forward;
function method1(v0: TArray0): LongInt; forward;
procedure method0(v0: TArray0);
var
  v1: LongInt;
begin
  v1 := 4;
  DynamicArrayReserve0(v0,v1);
end;
function method4(v0: LongInt; v1: TArray0): LongInt;
var
  v2: LongInt;
  v3: Boolean;
  v4: LongInt;
begin
  v2 := v0 - 1;
  v3 := v2 = 0;
  if v3 then begin
      v4 := v1[0];
      Result := v4;
  end else begin
      Result := method2(v2, v1);
  end;
end;
function method3(v0: LongInt; v1: TArray0): LongInt;
var
  v2: LongInt;
  v3: Boolean;
begin
  v2 := v0 - 1;
  v3 := v2 = 0;
  if v3 then begin
      Result := 99;
  end else begin
      Result := method4(v2, v1);
  end;
end;
function method2(v0: LongInt; v1: TArray0): LongInt;
var
  v2: LongInt;
  v3: Boolean;
begin
  v2 := v0 - 1;
  v3 := v2 = 0;
  if v3 then begin
      Result := 99;
  end else begin
      Result := method3(v2, v1);
  end;
end;
function method1(v0: TArray0): LongInt;
var
  v1: LongInt;
  v2: Boolean;
  v3: LongInt;
begin
  v1 := 1000002;
  v2 := v1 = 0;
  if v2 then begin
      v3 := v0[0];
      Result := v3;
  end else begin
      Result := method2(v1, v0);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: Boolean;
  v4: LongInt;
  v5: Boolean;
begin
  v0 := 1;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 7;
  method0(v1);
  v2 := method1(v1);
  v1[0] := 17;
  v3 := v2 = 7;
  if v3 then begin
      v4 := v1[0];
      v5 := v4 = 17;
      if v5 then begin
          Result := 0;
      end else begin
          Result := 2;
      end;
  end else begin
      Result := 1;
  end;
end;
begin
  Halt(SpiralMain);
end.
