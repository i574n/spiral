program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method0(v0: Boolean): AnsiString; forward;
function method1(v0: Boolean): AnsiString; forward;
function method0(v0: Boolean): AnsiString;
var
  v1: AnsiString;
  v2: AnsiString;
begin
  if v0 then begin
      v1 := 'spi';
      Result := v1;
  end else begin
      v2 := 'bad';
      Result := v2;
  end;
end;
function method1(v0: Boolean): AnsiString;
var
  v1: AnsiString;
  v2: AnsiString;
begin
  if v0 then begin
      v1 := 'bad';
      Result := v1;
  end else begin
      v2 := 'ral';
      Result := v2;
  end;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v1: AnsiString;
  v2: Boolean;
  v3: AnsiString;
  v4: AnsiString;
  v5: LongInt;
  v6: Boolean;
  v7: AnsiChar;
  v8: Boolean;
  v9: AnsiChar;
  v10: Boolean;
begin
  v0 := True;
  v1 := method0(v0);
  v2 := False;
  v3 := method1(v2);
  v4 := v1 + v3;
  v5 := LongInt(Length(v4));
  v6 := v5 = 6;
  if v6 then begin
      v7 := v4[0 + 1];
      v8 := v7 = 's';
      if v8 then begin
          v9 := v4[5 + 1];
          v10 := v9 = 'l';
          if v10 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end else begin
          Result := 2;
      end;
  end else begin
      Result := 3;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
