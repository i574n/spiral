program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
function method1(v0: LongInt; v1: TArray0; v2: TArray0): TArray0; forward;
function method0(v0: TArray0; v1: TArray0): TArray0; forward;
function method1(v0: LongInt; v1: TArray0; v2: TArray0): TArray0;
var
  v3: LongInt;
  v4: Boolean;
  tmp2: LongInt;
  tmp3: TArray0;
  tmp4: TArray0;
begin
  while True do begin
      v3 := v0 - 1;
      v4 := v3 = 0;
      if v4 then begin
          Result := v2;
          Exit;
      end else begin
          tmp2 := v3;
          tmp3 := v2;
          tmp4 := v1;
          v0 := tmp2;
          v1 := tmp3;
          v2 := tmp4;
          Continue;
      end;
  end;
end;
function method0(v0: TArray0; v1: TArray0): TArray0;
var
  v2: LongInt;
  v3: Boolean;
begin
  v2 := 1000000;
  v3 := v2 = 0;
  if v3 then begin
      Result := v0;
  end else begin
      Result := method1(v2, v0, v1);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: TArray0;
  tmp4: TArray0;
  v3: TArray0;
  v4: LongInt;
  v5: Boolean;
  v6: LongInt;
  v7: Boolean;
begin
  v0 := 1;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  tmp4 := nil;
  SetLength(tmp4, v0);
  v2 := tmp4;
  v1[0] := 7;
  v2[0] := 11;
  v3 := method0(v1, v2);
  v3[0] := 13;
  v4 := v1[0];
  v5 := v4 = 13;
  if v5 then begin
      v6 := v2[0];
      v7 := v6 = 11;
      if v7 then begin
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
