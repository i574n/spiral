program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function StringSlice(const value: AnsiString; from, upto: Int64): AnsiString;
var len: Int64;
begin
  len := Length(value);
  if (from < 0) or (from > len) or (upto < from - 1) or (upto >= len) then Halt(3);
  if upto < from then Exit('');
  if ((Ord(value[from + 1]) and $C0) = $80) or ((upto + 1 < len) and ((Ord(value[upto + 2]) and $C0) = $80)) then Halt(3);
  Result := Copy(value, from + 1, upto - from + 1);
end;
function method0(v0: AnsiString): AnsiString; forward;
function method0(v0: AnsiString): AnsiString;
var
  v1: AnsiString;
begin
  v1 := StringSlice(v0, 1, 3);
  Result := v1;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: LongInt;
  v5: Boolean;
  v6: AnsiChar;
  v7: Boolean;
  v8: AnsiChar;
  v9: Boolean;
begin
  v0 := 'alpha';
  v1 := method0(v0);
  v2 := method0(v0);
  v3 := method0(v0);
  v4 := LongInt(Length(v3));
  v5 := v4 = 3;
  if v5 then begin
      v6 := v3[0 + 1];
      v7 := v6 = 'l';
      if v7 then begin
          v8 := v3[2 + 1];
          v9 := v8 = 'h';
          if v9 then begin
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
