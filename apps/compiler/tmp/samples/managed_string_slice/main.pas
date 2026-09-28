program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

function SpiralStringIndex(const value: AnsiString; index: LongInt): Byte;
begin
  if (index < 0) or (index >= Length(value)) then raise ERangeError.Create('Spiral string index out of bounds');
  Result := Ord(value[index + 1]);
end;

function SpiralStringSlice(const value: AnsiString; fromIndex, toIndex: LongInt): AnsiString;
begin
  if (fromIndex < 0) or (fromIndex > Length(value)) or (toIndex < fromIndex - 1) or (toIndex >= Length(value)) then raise ERangeError.Create('Spiral string slice out of bounds');
  if (toIndex >= fromIndex) and ((((Ord(value[fromIndex + 1])) and $C0) = $80) or ((toIndex + 1 < Length(value)) and (((Ord(value[toIndex + 2])) and $C0) = $80))) then raise ERangeError.Create('Spiral string slice must preserve UTF-8 codepoint boundaries');
  if toIndex < fromIndex then Result := ''
  else Result := Copy(value, fromIndex + 1, toIndex - fromIndex + 1);
end;

function middle0(v0: AnsiString): AnsiString;
var
  v1: AnsiString;
begin
  v1 := SpiralStringSlice(v0, 1, 3);
  Exit(v1);
end;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: LongInt;
  v3: Boolean;
  v4: Byte;
  v5: Boolean;
  v6: Byte;
  v7: Boolean;
begin
  v0 := 'alpha';
  v1 := middle0(v0);
  v2 := Length(v1);
  v3 := (v2 = 3);
  if v3 then begin
    v4 := SpiralStringIndex(v1, 0);
    v5 := (v4 = 108);
    if v5 then begin
      v6 := SpiralStringIndex(v1, 2);
      v7 := (v6 = 104);
      if v7 then begin
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
end;

begin
  Halt(SpiralMain);
end.
