program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TTuple0 = record f0: Boolean; f1: Single; f2: LongInt; end;
function method0(v0: Single): TTuple0; forward;
function method1(v0: LongInt; v1: Single; v2: Boolean): LongInt; forward;
function TupleCreate0(f0: Boolean; f1: Single; f2: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1; Result.f2 := f2;
end;
function method0(v0: Single): TTuple0;
var
  v1: Boolean;
begin
  v1 := v0 >= 3.5;
  Result := TupleCreate0(v1, v0, 7);
end;
function method1(v0: LongInt; v1: Single; v2: Boolean): LongInt;
var
  v3: Boolean;
  v4: LongInt;
begin
  if v2 then begin
      v3 := v1 >= 3.5;
      if v3 then begin
          v4 := v0 - 7;
          Result := v4;
      end else begin
          Result := 1;
      end;
  end else begin
      Result := 2;
  end;
end;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: Boolean;
  v2: Single;
  v3: LongInt;
  tmp4: TTuple0;
begin
  v0 := 4.0;
  tmp4 := method0(v0);
  v1 := tmp4.f0;
  v2 := tmp4.f1;
  v3 := tmp4.f2;
  Result := method1(v3, v2, v1);
end;
begin
  Halt(SpiralMain);
end.
