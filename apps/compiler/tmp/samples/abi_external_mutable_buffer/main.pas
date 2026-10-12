program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TArray0 = array of Byte;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: Boolean;
  v6: Byte;
  v7: Boolean;
  v8: Byte;
  v9: Boolean;
  v10: Byte;
  v11: Boolean;
  v12: Byte;
  v13: Boolean;
begin
  v0 := 4;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 0;
  v1[1] := 0;
  v1[2] := 0;
  v1[3] := 0;
  v2 := 65;
  v3 := 3;
  v4 := spiral_abi_libc_memset(v1,v2,v3);
  v5 := v4 = 3;
  if v5 then begin
      v6 := v1[0];
      v7 := v6 = 65;
      if v7 then begin
          v8 := v1[1];
          v9 := v8 = 65;
          if v9 then begin
              v10 := v1[2];
              v11 := v10 = 65;
              if v11 then begin
                  v12 := v1[3];
                  v13 := v12 = 0;
                  if v13 then begin
                      Result := 0;
                  end else begin
                      Result := 4;
                  end;
              end else begin
                  Result := 3;
              end;
          end else begin
              Result := 2;
          end;
      end else begin
          Result := 1;
      end;
  end else begin
      Result := 5;
  end;
end;
begin
  Halt(SpiralMain);
end.
