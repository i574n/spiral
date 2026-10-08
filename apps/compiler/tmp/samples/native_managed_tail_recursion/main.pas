program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method1(v0: LongInt; v1: AnsiString): AnsiString; forward;
function method0: AnsiString; forward;
function method1(v0: LongInt; v1: AnsiString): AnsiString;
var
  v2: LongInt;
  v3: Boolean;
  v4: LongInt;
  v5: Boolean;
  v8: AnsiString;
  v6: AnsiString;
  v7: AnsiString;
  tmp7: LongInt;
  tmp8: AnsiString;
begin
  while True do begin
      v2 := v0 - 1;
      v3 := v2 = 0;
      if v3 then begin
          Result := v1;
          Exit;
      end else begin
          v4 := v2 mod 2;
          v5 := v4 = 0;
          if v5 then begin
              v6 := 'ok';
              v8 := v6;
          end else begin
              v7 := 'go';
              v8 := v7;
          end;
          tmp7 := v2;
          tmp8 := v8;
          v0 := tmp7;
          v1 := tmp8;
          Continue;
      end;
  end;
end;
function method0: AnsiString;
var
  v0: LongInt;
  v1: Boolean;
  v2: AnsiString;
  v3: LongInt;
  v4: Boolean;
  v7: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
begin
  v0 := 1000000;
  v1 := v0 = 0;
  if v1 then begin
      v2 := 'seed';
      Result := v2;
  end else begin
      v3 := v0 mod 2;
      v4 := v3 = 0;
      if v4 then begin
          v5 := 'ok';
          v7 := v5;
      end else begin
          v6 := 'go';
          v7 := v6;
      end;
      Result := method1(v0, v7);
  end;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: LongInt;
  v2: Boolean;
begin
  v0 := method0;
  v1 := LongInt(Length(v0));
  v2 := v1 = 2;
  if v2 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
