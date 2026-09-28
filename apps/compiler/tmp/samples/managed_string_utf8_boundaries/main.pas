program SpiralGenerated;
{$mode delphi}{$H+}
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
function method1(v0: AnsiString): AnsiString; forward;
function method0(v0: AnsiString): AnsiString;
var
  v1: AnsiString;
begin
  v1 := StringSlice(v0, 0, 1);
  Result := v1;
end;
function method1(v0: AnsiString): AnsiString;
var
  v1: AnsiString;
begin
  v1 := StringSlice(v0, 2, 3);
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
  v6: LongInt;
  v7: Boolean;
  v8: LongInt;
  v9: Boolean;
begin
  v0 := #195#169#206#187;
  v1 := method0(v0);
  v2 := method1(v0);
  v3 := v1 + v2;
  v4 := LongInt(Length(v1));
  v5 := v4 = 2;
  if v5 then begin
      v6 := LongInt(Length(v2));
      v7 := v6 = 2;
      if v7 then begin
          v8 := LongInt(Length(v3));
          v9 := v8 = 4;
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
