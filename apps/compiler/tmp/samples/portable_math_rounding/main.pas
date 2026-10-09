program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: Double;
  v1: Double;
  v2: Double;
  v3: Double;
  v4: Double;
  v5: Double;
  v6: Single;
  v21: Double;
  v23: Boolean;
  v24: Boolean;
  v40: Double;
  v42: Boolean;
  v43: Boolean;
  v158: Double;
  v159: Double;
  v160: Boolean;
  v170: Double;
  v161: Double;
  v162: Boolean;
  v163: Double;
  v164: Double;
  v165: Double;
  v166: Boolean;
  v167: Double;
  v172: Boolean;
  v173: Boolean;
  v174: Double;
  v175: Double;
  v176: Boolean;
  v186: Double;
  v177: Double;
  v178: Boolean;
  v179: Double;
  v180: Double;
  v181: Double;
  v182: Boolean;
  v183: Double;
  v187: Boolean;
  v188: Boolean;
  v189: Double;
  v190: Double;
  v191: Boolean;
  v201: Double;
  v192: Double;
  v193: Boolean;
  v194: Double;
  v195: Double;
  v196: Double;
  v197: Boolean;
  v198: Double;
  v202: Boolean;
  v203: Boolean;
  v204: Double;
  v205: Double;
  v206: Boolean;
  v216: Double;
  v207: Double;
  v208: Boolean;
  v209: Double;
  v210: Double;
  v211: Double;
  v212: Boolean;
  v213: Double;
  v217: Boolean;
  v218: Boolean;
  v219: Double;
  v220: Double;
  v221: Boolean;
  v231: Double;
  v222: Double;
  v223: Boolean;
  v224: Double;
  v225: Double;
  v226: Double;
  v227: Boolean;
  v228: Double;
  v232: Boolean;
  v233: Boolean;
  v245: Double;
  v247: Double;
  v248: Double;
  v249: Boolean;
  v250: Boolean;
  v265: Single;
  v267: Boolean;
  v268: Boolean;
begin
  v0 := 2.7;
  v1 := 3.2;
  v2 := (-2.5);
  v3 := 3.5;
  v4 := 0.5;
  v5 := 1.0;
  v6 := 2.7;
  v21 := Int(v0) - Ord(Frac(v0) < 0);
  v23 := v21 = 2.0;
  v24 := v23 <> True;
  if v24 then begin
      Result := 1;
  end else begin
      v40 := Int(v0) + Ord(Frac(v0) > 0);
      v42 := v40 = 3.0;
      v43 := v42 <> True;
      if v43 then begin
          Result := 2;
      end else begin
          v158 := Int(v0) - Ord(Frac(v0) < 0);
          v159 := v0 - v158;
          v160 := v159 > 0.5;
          if v160 then begin
              v161 := v158 + 1.0;
              v170 := v161;
          end else begin
              v162 := v159 < 0.5;
              if v162 then begin
                  v170 := v158;
              end else begin
                  v163 := v158 / 2.0;
                  v164 := Int(v163) - Ord(Frac(v163) < 0);
                  v165 := v164 * 2.0;
                  v166 := v165 = v158;
                  if v166 then begin
                      v170 := v158;
                  end else begin
                      v167 := v158 + 1.0;
                      v170 := v167;
                  end;
              end;
          end;
          v172 := v170 = 3.0;
          v173 := v172 <> True;
          if v173 then begin
              Result := 3;
          end else begin
              v174 := Int(v1) - Ord(Frac(v1) < 0);
              v175 := v1 - v174;
              v176 := v175 > 0.5;
              if v176 then begin
                  v177 := v174 + 1.0;
                  v186 := v177;
              end else begin
                  v178 := v175 < 0.5;
                  if v178 then begin
                      v186 := v174;
                  end else begin
                      v179 := v174 / 2.0;
                      v180 := Int(v179) - Ord(Frac(v179) < 0);
                      v181 := v180 * 2.0;
                      v182 := v181 = v174;
                      if v182 then begin
                          v186 := v174;
                      end else begin
                          v183 := v174 + 1.0;
                          v186 := v183;
                      end;
                  end;
              end;
              v187 := v186 = 3.0;
              v188 := v187 <> True;
              if v188 then begin
                  Result := 4;
              end else begin
                  v189 := Int(v2) - Ord(Frac(v2) < 0);
                  v190 := v2 - v189;
                  v191 := v190 > 0.5;
                  if v191 then begin
                      v192 := v189 + 1.0;
                      v201 := v192;
                  end else begin
                      v193 := v190 < 0.5;
                      if v193 then begin
                          v201 := v189;
                      end else begin
                          v194 := v189 / 2.0;
                          v195 := Int(v194) - Ord(Frac(v194) < 0);
                          v196 := v195 * 2.0;
                          v197 := v196 = v189;
                          if v197 then begin
                              v201 := v189;
                          end else begin
                              v198 := v189 + 1.0;
                              v201 := v198;
                          end;
                      end;
                  end;
                  v202 := v201 = (-2.0);
                  v203 := v202 <> True;
                  if v203 then begin
                      Result := 5;
                  end else begin
                      v204 := Int(v3) - Ord(Frac(v3) < 0);
                      v205 := v3 - v204;
                      v206 := v205 > 0.5;
                      if v206 then begin
                          v207 := v204 + 1.0;
                          v216 := v207;
                      end else begin
                          v208 := v205 < 0.5;
                          if v208 then begin
                              v216 := v204;
                          end else begin
                              v209 := v204 / 2.0;
                              v210 := Int(v209) - Ord(Frac(v209) < 0);
                              v211 := v210 * 2.0;
                              v212 := v211 = v204;
                              if v212 then begin
                                  v216 := v204;
                              end else begin
                                  v213 := v204 + 1.0;
                                  v216 := v213;
                              end;
                          end;
                      end;
                      v217 := v216 = 4.0;
                      v218 := v217 <> True;
                      if v218 then begin
                          Result := 6;
                      end else begin
                          v219 := Int(v4) - Ord(Frac(v4) < 0);
                          v220 := v4 - v219;
                          v221 := v220 > 0.5;
                          if v221 then begin
                              v222 := v219 + 1.0;
                              v231 := v222;
                          end else begin
                              v223 := v220 < 0.5;
                              if v223 then begin
                                  v231 := v219;
                              end else begin
                                  v224 := v219 / 2.0;
                                  v225 := Int(v224) - Ord(Frac(v224) < 0);
                                  v226 := v225 * 2.0;
                                  v227 := v226 = v219;
                                  if v227 then begin
                                      v231 := v219;
                                  end else begin
                                      v228 := v219 + 1.0;
                                      v231 := v228;
                                  end;
                              end;
                          end;
                          v232 := v231 = 0.0;
                          v233 := v232 <> True;
                          if v233 then begin
                              Result := 7;
                          end else begin
                              v245 := ArcTan2(v5, v5);
                              v247 := v245 * 1000.0;
                              v248 := Int(v247) - Ord(Frac(v247) < 0);
                              v249 := v248 = 785.0;
                              v250 := v249 <> True;
                              if v250 then begin
                                  Result := 8;
                              end else begin
                                  v265 := Int(v6) - Ord(Frac(v6) < 0);
                                  v267 := v265 = 2.0;
                                  v268 := v267 <> True;
                                  if v268 then begin
                                      Result := 9;
                                  end else begin
                                      Result := 0;
                                  end;
                              end;
                          end;
                      end;
                  end;
              end;
          end;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
