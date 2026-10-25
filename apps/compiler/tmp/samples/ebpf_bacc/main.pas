program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method1(v0: LongInt; v1: Boolean): Boolean; forward;
function method0(v0: LongInt): Boolean; forward;
function method2(v0: LongInt): Boolean; forward;
function method1(v0: LongInt; v1: Boolean): Boolean;
var
  v2: LongInt;
  v4: Boolean;
  v3: Boolean;
  v5: Boolean;
  tmp4: LongInt;
  tmp5: Boolean;
begin
  while True do begin
      v2 := v0 - 1;
      if v1 then begin
          v3 := v0 > 0;
          v4 := v3;
      end else begin
          v4 := False;
      end;
      v5 := v2 = 0;
      if v5 then begin
          Result := v4;
          Exit;
      end else begin
          tmp4 := v2;
          tmp5 := v4;
          v0 := tmp4;
          v1 := tmp5;
          Continue;
      end;
  end;
end;
function method0(v0: LongInt): Boolean;
var
  v1: Boolean;
  v2: Boolean;
begin
  v1 := True;
  v2 := v0 = 0;
  if v2 then begin
      Result := v1;
  end else begin
      Result := method1(v0, v1);
  end;
end;
function method2(v0: LongInt): Boolean;
var
  v1: Boolean;
  v2: Boolean;
begin
  v1 := False;
  v2 := v0 = 0;
  if v2 then begin
      Result := v1;
  end else begin
      Result := method1(v0, v1);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
  v2: Boolean;
begin
  v0 := 3;
  v1 := method0(v0);
  v2 := method2(v0);
  if v1 then begin
      if v2 then begin
          Result := 1;
      end else begin
          Result := 0;
      end;
  end else begin
      Result := 2;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
