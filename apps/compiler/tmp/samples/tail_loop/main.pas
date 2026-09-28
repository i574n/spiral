program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
function method1(v0: LongInt; v1: LongInt): LongInt; forward;
function method0(v0: LongInt): LongInt; forward;
function method1(v0: LongInt; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: Boolean;
  tmp3: LongInt;
  tmp4: LongInt;
begin
  while True do begin
      v2 := v0 - 1;
      v3 := v1 + v0;
      v4 := v2 = 0;
      if v4 then begin
          Result := v3;
          Exit;
      end else begin
          tmp3 := v2;
          tmp4 := v3;
          v0 := tmp3;
          v1 := tmp4;
          Continue;
      end;
  end;
end;
function method0(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: Boolean;
  v4: LongInt;
  v5: LongInt;
begin
  v1 := 0;
  v2 := v0 = 0;
  if v2 then begin
      v4 := v1;
  end else begin
      v4 := method1(v0, v1);
  end;
  v5 := v4 - 55;
  Result := v5;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := 10;
  Result := method0(v0);
end;
begin
  Halt(SpiralMain);
end.
