program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

function SpiralStringSlice(const value: AnsiString; fromIndex, toIndex: LongInt): AnsiString;
begin
  if (fromIndex < 0) or (fromIndex > Length(value)) or (toIndex < fromIndex - 1) or (toIndex >= Length(value)) then raise ERangeError.Create('Spiral string slice out of bounds');
  if (toIndex >= fromIndex) and ((((Ord(value[fromIndex + 1])) and $C0) = $80) or ((toIndex + 1 < Length(value)) and (((Ord(value[toIndex + 2])) and $C0) = $80))) then raise ERangeError.Create('Spiral string slice must preserve UTF-8 codepoint boundaries');
  if toIndex < fromIndex then Result := ''
  else Result := Copy(value, fromIndex + 1, toIndex - fromIndex + 1);
end;

function SpiralStringConcat(const left, right: AnsiString): AnsiString;
begin
  Result := left + right;
end;

function first_codepoint0(v0: AnsiString): AnsiString;
var
  v1: AnsiString;
begin
  v1 := SpiralStringSlice(v0, 0, 1);
  Exit(v1);
end;

function second_codepoint1(v0: AnsiString): AnsiString;
var
  v1: AnsiString;
begin
  v1 := SpiralStringSlice(v0, 2, 3);
  Exit(v1);
end;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: Boolean;
  v5: LongInt;
  v6: Boolean;
  v7: LongInt;
  v8: Boolean;
  v9: LongInt;
  v10: Boolean;
begin
  v0 := 'éλ';
  v1 := first_codepoint0(v0);
  v2 := second_codepoint1(v0);
  v3 := SpiralStringConcat(v1, v2);
  v4 := (4 = 4);
  if v4 then begin
    v5 := Length(v1);
    v6 := (v5 = 2);
    if v6 then begin
      v7 := Length(v2);
      v8 := (v7 = 2);
      if v8 then begin
        v9 := Length(v3);
        v10 := (v9 = 4);
        if v10 then begin
          Exit(0);
        end else begin
          Exit(1);
        end;
      end else begin
        Exit(2);
      end;
    end else begin
      Exit(3);
    end;
  end else begin
    Exit(4);
  end;
end;

begin
  Halt(SpiralMain);
end.
