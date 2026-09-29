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
  v4: Boolean;
  v5: AnsiString;
  v6: Boolean;
  v7: AnsiString;
  v8: Boolean;
  v9: AnsiString;
  v10: AnsiString;
  v11: LongInt;
  v12: Boolean;
  v13: AnsiChar;
  v14: Boolean;
  v15: AnsiChar;
  v16: Boolean;
begin
  v0 := True;
  v1 := method0(v0);
  v2 := True;
  v3 := method0(v2);
  v4 := True;
  v5 := method0(v4);
  v6 := True;
  v7 := method0(v6);
  v8 := False;
  v9 := method1(v8);
  v10 := v7 + v9;
  v11 := LongInt(Length(v10));
  v12 := v11 = 6;
  if v12 then begin
      v13 := v10[0 + 1];
      v14 := v13 = 's';
      if v14 then begin
          v15 := v10[5 + 1];
          v16 := v15 = 'l';
          if v16 then begin
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
begin
  Halt(SpiralMain);
end.
